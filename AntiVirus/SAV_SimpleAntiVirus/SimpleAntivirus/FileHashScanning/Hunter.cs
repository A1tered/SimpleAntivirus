﻿/**************************************************************************
 * File:        Hunter.cs
 * Author:      Joel Parks
 * Description: Gathers hashes from database and compares them to system files.
 * Last Modified: 21/10/2024
 **************************************************************************/

using System.IO;
using System.Diagnostics;

namespace SimpleAntivirus.FileHashScanning
{
    /// <summary>
    /// Hunter Class
    /// Responsibilities: Given a directory, is responsible for hashing items and comparing to database.
    /// </summary>
    /// 
    public class Hunter
    {
        private string _directoryToScan;
        private DatabaseConnector _databaseConnection;
        public Hasher _hasher;
        private string _databaseDirectory;
        private readonly CancellationToken _token;

        public Hunter(string directoryToScan, string databaseDirectory, CancellationToken token)
        {
            _directoryToScan = directoryToScan;
            _databaseConnection = new DatabaseConnector(databaseDirectory);
            _token = token;
            _hasher = new Hasher();
        }

        public async Task<Tuple<string[], string[]>> SearchDirectory(FileHashScanner scanner)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Debug.WriteLine($"Hunter currently scanning directory {_directoryToScan}");

                    string[] files = Directory.GetFiles(_directoryToScan);
                    string[] directoryRemnants = Directory.GetDirectories(_directoryToScan);
                    List<string> violationsList = new List<string>();

                    foreach (string file in files)
                    {
                        if (_token.IsCancellationRequested)
                        {
                            _token.ThrowIfCancellationRequested();
                        }

                        Debug.WriteLine($"Current file: {file}");

                        if (CompareCycle(file))
                        {
                            violationsList.Add(file);
                        }
                    }
                    foreach (string violation in violationsList)
                    {
                        await scanner.QuarantineManager.QuarantineFileAsync(violation, scanner.EventBus, "filehash");
                    }
                    return Tuple.Create(violationsList.ToArray(), directoryRemnants);
                }
                catch (Exception exception)
                {
                    if (exception is IOException || exception is AccessViolationException || exception is UnauthorizedAccessException)
                    {
                        Debug.WriteLine($"IO Exception. Cannot open directory {_directoryToScan}");
                        return Tuple.Create(Array.Empty<string>(), Array.Empty<string>());
                    }
                    throw;
                }
                finally
                {
                    _databaseConnection.CleanUp();
                }
            }, scanner.Token);
        }

        public bool CompareCycle(string fileDirectory)
        {
            string hashGet = _hasher.OpenHashFile(fileDirectory);
            if (hashGet != "Non-readable")
            {
                return _databaseConnection.QueryHash(hashGet);
            }
            return false;
        }

        public int[] CompareCycleBatch(string[] fileDirectory)
        {
            string[] hashGetArray = _hasher.OpenHashFileBatch(fileDirectory);
            int[] indexDetections = _databaseConnection.QueryHashBatch(hashGetArray);
            return indexDetections;
        }
    }
}
