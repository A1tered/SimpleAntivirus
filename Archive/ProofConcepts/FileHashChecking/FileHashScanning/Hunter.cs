﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHashScanning
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

        public Hunter(string directoryToScan, string databaseDirectory)
        {
            _directoryToScan = directoryToScan;
            _databaseConnection = new DatabaseConnector(databaseDirectory);
            _hasher = new Hasher();

        }

        public async Task<Tuple<string[], string[]>> SearchDirectory()
        {
            return await Task.Run(() =>
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Hunter currently scanning directory {_directoryToScan}");

                    string[] files = Directory.GetFiles(_directoryToScan);
                    string[] directoryRemnants = Directory.GetDirectories(_directoryToScan);
                    List<string> violationsList = new List<string>();
                    foreach (string file in files)
                    {
                        if (CompareCycle(file))
                        {
                            violationsList.Add(file);
                            Violation(file);
                        }
                    }
                    return Tuple.Create(violationsList.ToArray(), directoryRemnants);
                }
                catch (Exception exception)
                {
                    if (exception is IOException || exception is AccessViolationException || exception is UnauthorizedAccessException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"IO Exception. Cannot open directory {_directoryToScan}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        return Tuple.Create(Array.Empty<string>(), Array.Empty<string>());
                    }
                    throw;
                }
                finally
                {
                    _databaseConnection.CleanUp();
                }
            });
        }

        private void Violation(string fileDirectory)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Violation found: {fileDirectory}");
            Console.ForegroundColor = ConsoleColor.Yellow;
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
