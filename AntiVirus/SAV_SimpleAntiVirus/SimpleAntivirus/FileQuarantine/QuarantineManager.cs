﻿/**************************************************************************
 * File:        QuarantineManager.cs
 * Author:      Zachary Smith
 * Description: Sends alerts, and prepares file for quarantine.
 * Last Modified: 21/10/2024
 **************************************************************************/

using SimpleAntivirus.Alerts;
using System.Diagnostics;
using System.IO;

namespace SimpleAntivirus.FileQuarantine
{
    public class QuarantineManager : IQuarantineManager
    {
        private readonly FileMover _fileMover;
        private readonly IDatabaseManager _databaseManager;
        private readonly string _quarantineDirectory;

        // Constructor for QuarantineManager. Initializes file mover, database manager, and quarantine directory.
        public QuarantineManager(FileMover fileMover, IDatabaseManager databaseManager, string quarantineDirectory)
        {
            _fileMover = fileMover;
            _databaseManager = databaseManager;
            _quarantineDirectory = quarantineDirectory;

            // Ensure quarantine directory exists
            if (!Directory.Exists(_quarantineDirectory))
            {
                Directory.CreateDirectory(_quarantineDirectory);
                Debug.WriteLine($"Quarantine directory created at {_quarantineDirectory}");
            }
        }

        // QuarantineFileAsync handles quarantining a file: moving it to quarantine and updating the database
        public async Task QuarantineFileAsync(string filePath, EventBus eventBus, string scanType)
        {
            try
            {
                // Check if the file is already whitelisted
                if (await _databaseManager.IsWhitelistedAsync(filePath) && scanType == "filehash")
                {
                    await eventBus.PublishAsync("File Hash Scanning", "Low", $"Whitelisted threat detected at location: {filePath}", "Ensure only safe files are whitelisted");
                    Debug.WriteLine($"File or folder is whitelisted and will not be quarantined: {filePath}");
                    return;
                }
                else if (await _databaseManager.IsWhitelistedAsync(filePath) && scanType == "maliciouscode")
                {
                    await eventBus.PublishAsync("Malicious Code Scanning", "Low", $"Whitelisted threat detected at location: {filePath}", "Ensure only safe files are whitelisted");
                    Debug.WriteLine($"File or folder is whitelisted and will not be quarantined: {filePath}");
                    return;
                }
                else
                {
                    // Move the file to the quarantine directory
                    string quarantinePath = await _fileMover.MoveFileToQuarantineAsync(filePath, _quarantineDirectory);
                    
                    if (quarantinePath != null)
                    {
                        // Send alert
                        if (scanType == "filehash")
                        {
                            await eventBus.PublishAsync("File Hash Scanning", "Severe", $"Threat found! File: {filePath} has been found and quarantined.", "No action is required. You may unquarantine or delete if you choose.");
                        }
                        else if (scanType == "maliciouscode")
                        {
                            await eventBus.PublishAsync("Malicious Code Scanning", "Severe", $"Threat found! File: {filePath} has been found and quarantined.", "No action is required. You may unquarantine or delete if you choose.");
                        }

                        // Remove file permissions to prevent unauthorized access
                        await RemoveFilePermissionsUsingPowerShell(quarantinePath);

                        // Store the quarantine info (path, original location) in the database
                        await _databaseManager.StoreQuarantineInfoAsync(quarantinePath, filePath);

                        // Log the quarantined file's location securely
                        await LogQuarantinedFileLocationAsync(quarantinePath);
                    }
                    else
                    {
                        if (scanType == "filehash")
                        {
                            await eventBus.PublishAsync("File Hash Scanning", "Medium", $"File Quarantine Failed. A threat has been found but was unable to be quarantined.", $"Ensure that {filePath} is safe or does not exist. It is likely a protected system file that SAV cannot quarantine.");
                        }
                        else if (scanType == "maliciouscode")
                        {
                            await eventBus.PublishAsync("Malicious Code Scanning", "Medium", $"File Quarantine Failed. A threat has been found but was unable to be quarantined.", $"Ensure that {filePath} is safe or does not exist. It is likely a protected system file that SAV cannot quarantine.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors during the quarantine process
                Debug.WriteLine($"Error during quarantine process: {ex.Message}");
            }
        }

        // UnquarantineFileAsync restores a quarantined file back to its original location
        public async Task<bool> UnquarantineFileAsync(int id)
        {
            try
            {
                var fileData = await _databaseManager.GetQuarantinedFileByIdAsync(id);
                if (fileData == null)
                {
                    Debug.WriteLine($"No file found with ID: {id}");
                    return false;
                }

                string quarantinedFilePath = fileData.Value.QuarantinedFilePath;
                string originalFilePath = fileData.Value.OriginalFilePath;

                // Restore the file's original permissions before moving it
                await RestoreFilePermissionsUsingPowerShell(quarantinedFilePath);

                // Move the file back to its original location
                if (File.Exists(quarantinedFilePath))
                {
                    // Ensure the directory for the original location exists
                    string originalDirectory = Path.GetDirectoryName(originalFilePath);
                    if (!Directory.Exists(originalDirectory))
                    {
                        Directory.CreateDirectory(originalDirectory);
                        Debug.WriteLine($"Created directory: {originalDirectory}");
                    }

                    File.Move(quarantinedFilePath, originalFilePath);
                    Debug.WriteLine($"File unquarantined and moved back to: {originalFilePath}");

                    // Remove the quarantine entry from the database
                    await _databaseManager.RemoveQuarantineEntryAsync(id);
                    return true;
                }
                else
                {
                    Debug.WriteLine($"File not found in quarantine: {quarantinedFilePath}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any errors during the unquarantine process
                Debug.WriteLine($"Error during unquarantine process: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteFileAsync(string filePath)
        {
            try
            {
                // Delete the file
                await DeleteFileUsingPowerShell(filePath);
                return true;
            }
            catch (Exception ex)
            {
                // Handle any errors during the quarantine process
                Debug.WriteLine($"Error during quarantine process: {ex.Message}");
                return false;
            }
        }

        // Retrieves all quarantined files from the database
        public async Task<IEnumerable<(int Id, string QuarantinedFilePath, string OriginalFilePath, string QuarantineDate)>> GetQuarantinedFilesAsync()
        {
            return await _databaseManager.GetAllQuarantinedFilesAsync();
        }

        // Logs the quarantined file's location to a secure log file
        private async Task LogQuarantinedFileLocationAsync(string filePath)
        {
            try
            {
                string logFilePath = Path.Combine(_quarantineDirectory, "quarantine_log.txt");
                string logEntry = $"[{DateTime.Now}] Quarantined file located at: {filePath}";

                // Log file location asynchronously
                await File.AppendAllTextAsync(logFilePath, logEntry + Environment.NewLine);
                Debug.WriteLine("Quarantined file location logged securely.");
            }
            catch (Exception ex)
            {
                // Handle logging errors
                Debug.WriteLine($"Error logging quarantined file location: {ex.Message}");
            }
        }

        // Uses PowerShell to remove file permissions for a quarantined file
        private async Task RemoveFilePermissionsUsingPowerShell(string filePath)
        {
            string command = $"icacls '{filePath}' /deny '{Environment.UserName}:F'";
            await RunPowerShellCommandAsync(command);
        }

        // Uses PowerShell to restore file permissions for a file being unquarantined
        private async Task RestoreFilePermissionsUsingPowerShell(string filePath)
        {
            string command = $"icacls '{filePath}' /grant '{Environment.UserName}:F'";
            await RunPowerShellCommandAsync(command);
        }
        
        // Uses PowerShell to delete a quarantined file from the computer permanently.
        private async Task DeleteFileUsingPowerShell(string filePath)
        {
            string command = $"Remove-Item '{filePath}'";
            Debug.WriteLine($"Ran command: {command}");
            await RunPowerShellCommandAsync(command);
        }

        // Executes a PowerShell command asynchronously
        private async Task<bool> RunPowerShellCommandAsync(string command)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-Command \"{command}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                process.Start();

                // Capture output and wait for the command to finish executing
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();
                await process.WaitForExitAsync();

                if (process.ExitCode == 0)
                {
                    Debug.WriteLine($"Command executed successfully: {output}");
                    return true;
                }
                else
                {
                    Debug.WriteLine($"Error executing command: {error}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle errors in PowerShell execution
                Debug.WriteLine($"Error executing PowerShell command: {ex.Message}");
                return false;
            }
        }
    }
}
