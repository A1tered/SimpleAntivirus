﻿using System.Diagnostics;

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
            Console.WriteLine($"Quarantine directory created at {_quarantineDirectory}");
        }
    }

    // QuarantineFileAsync handles quarantining a file: moving it to quarantine and updating the database
    public async Task QuarantineFileAsync(string filePath)
    {
        try
        {
            // Check if the file is already whitelisted
            if (await _databaseManager.IsWhitelistedAsync(filePath))
            {
                Console.WriteLine($"File or folder is whitelisted and will not be quarantined: {filePath}");
                return;
            }

            // Move the file to the quarantine directory
            string quarantinePath = await _fileMover.MoveFileToQuarantineAsync(filePath, _quarantineDirectory);

            // Remove file permissions to prevent unauthorized access
            await RemoveFilePermissionsUsingPowerShell(quarantinePath);

            // Store the quarantine info (path, original location) in the database
            await _databaseManager.StoreQuarantineInfoAsync(quarantinePath, filePath);

            // Log the quarantined file's location securely
            await LogQuarantinedFileLocationAsync(quarantinePath);
        }
        catch (Exception ex)
        {
            // Handle any errors during the quarantine process
            Console.WriteLine($"Error during quarantine process: {ex.Message}");
        }
    }

    // UnquarantineFileAsync restores a quarantined file back to its original location
    public async Task UnquarantineFileAsync(int id)
    {
        try
        {
            var fileData = await _databaseManager.GetQuarantinedFileByIdAsync(id);
            if (fileData == null)
            {
                Console.WriteLine($"No file found with ID: {id}");
                return;
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
                    Console.WriteLine($"Created directory: {originalDirectory}");
                }

                File.Move(quarantinedFilePath, originalFilePath);
                Console.WriteLine($"File unquarantined and moved back to: {originalFilePath}");

                // Remove the quarantine entry from the database
                await _databaseManager.RemoveQuarantineEntryAsync(id);
            }
            else
            {
                Console.WriteLine($"File not found in quarantine: {quarantinedFilePath}");
            }
        }
        catch (Exception ex)
        {
            // Handle any errors during the unquarantine process
            Console.WriteLine($"Error during unquarantine process: {ex.Message}");
        }
    }

    // Retrieves all quarantined files from the database
    public async Task<IEnumerable<(int Id, string QuarantinedFilePath, string OriginalFilePath)>> GetQuarantinedFilesAsync()
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
            Console.WriteLine("Quarantined file location logged securely.");
        }
        catch (Exception ex)
        {
            // Handle logging errors
            Console.WriteLine($"Error logging quarantined file location: {ex.Message}");
        }
    }

    // Uses PowerShell to remove file permissions for a quarantined file
    private async Task RemoveFilePermissionsUsingPowerShell(string filePath)
    {
        string command = $"icacls \"{filePath}\" /inheritance:r /remove:g \"Everyone\"";
        await RunPowerShellCommandAsync(command);
    }

    // Uses PowerShell to restore file permissions for a file being unquarantined
    private async Task RestoreFilePermissionsUsingPowerShell(string filePath)
    {
        string command = $"icacls \"{filePath}\" /grant Everyone:F";
        await RunPowerShellCommandAsync(command);
    }

    // Executes a PowerShell command asynchronously
    private async Task RunPowerShellCommandAsync(string command)
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
                Console.WriteLine($"Command executed successfully: {output}");
            }
            else
            {
                Console.WriteLine($"Error executing command: {error}");
            }
        }
        catch (Exception ex)
        {
            // Handle errors in PowerShell execution
            Console.WriteLine($"Error executing PowerShell command: {ex.Message}");
        }
    }
}
