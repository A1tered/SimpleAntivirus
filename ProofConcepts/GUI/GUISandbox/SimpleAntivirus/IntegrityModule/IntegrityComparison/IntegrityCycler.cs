﻿/**************************************************************************
 * File:        IntegrityCycler.cs
 * Author:      Christopher Thompson, etc.
 * Description: Manages the start of the Integrity Scanning process, deals with returned Violations when it initiates multiple 
 * Integrity data poolers to scan certain sets of database queries.
 * Last Modified: 26/08/2024
 **************************************************************************/

using SimpleAntivirus.IntegrityModule.Alerts;
using SimpleAntivirus.IntegrityModule.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAntivirus.IntegrityModule.Db;
using System.Diagnostics;

namespace SimpleAntivirus.IntegrityModule.IntegrityComparison
{
    public class IntegrityCycler
    {
        // How many data sets does 1 task undertake? (Higher = Less Speed/Less Intensive) (Lower = High Speed / More Intensive)
        private int _amountPerSet;
        private IntegrityDatabaseIntermediary _database;
        private ViolationHandler _violationHandler;
        public IntegrityCycler(IntegrityDatabaseIntermediary database, ViolationHandler violationHandler)
        {
            _database = database;
            _violationHandler = violationHandler;
            _amountPerSet = 500;
        }

        public event EventHandler<ProgressArgs> ProgressUpdate;

        /// <summary>
        /// Initiate scan of entire IntegrityDatabase and compare with real time system documents.
        /// </summary>
        /// <remarks>One of the most important functions.</remarks>
        public async Task<List<IntegrityViolation>> InitiateScan()
        {
            ProgressArgs setProgressArg;
            // Progress Track variables:
            // List that instantiates all the instances of Datapooler with proper configuration (Does not run them)
            List<IntegrityDataPooler> dataPoolerList = new();
            // Keep track of the running data poolers.
            List<Task<List<IntegrityViolation>>> taskList = new();
            // Track all violations that have been reported.
            List<IntegrityViolation> summaryViolation = new();
            int initialTaskAmount = 0;
            long amountEntry = _database.QueryAmount("IntegrityTrack");

            // TaskAmountComplete
            int taskAmountComplete = 0;

            // Task Items to delete
            List<Task<List<IntegrityViolation>>> taskToDelete = new();

            if (amountEntry == 0)
            {
                System.Diagnostics.Debug.WriteLine("No entries to scan");
                return summaryViolation;
            }
            decimal divison = (decimal)amountEntry / _amountPerSet;
            int sets = Convert.ToInt32(Math.Ceiling(divison));
            // For each set, give it to a pooler
            for (int cycle = 0; cycle < sets; cycle++)
            {
                dataPoolerList.Add(new IntegrityDataPooler(_database, cycle, _amountPerSet));
            }
            foreach (IntegrityDataPooler poolerObject in dataPoolerList)
            {
                taskList.Add(Task.Run(poolerObject.CheckIntegrity));
            }
            initialTaskAmount = taskList.Count();
            Debug.WriteLine($"Task Initial Amount:{taskList.Count()}");
            while (taskList.Count() > 0)
            {
                taskToDelete.Clear();
                await Task.WhenAny(taskList.ToArray());
                foreach (Task<List<IntegrityViolation>> taskItem in taskList)
                {
                    if (taskItem.IsCompleted)
                    {
                        taskToDelete.Add(taskItem);
                        taskAmountComplete++;
                        foreach (IntegrityViolation violationComponent in taskItem.Result)
                        {
                            summaryViolation.Add(violationComponent);
                            // For each violation, send to violation handler
                            await Task.Run(() => _violationHandler.ViolationAlert(violationComponent));

                            // Progress calculation here
                            setProgressArg = new();
                            // Percentage of tasks left.
                            setProgressArg.Progress = Math.Round(((taskAmountComplete) / (float)initialTaskAmount) * 100, 2);
                            setProgressArg.ProgressInfo = $"{_amountPerSet * (initialTaskAmount - taskAmountComplete)} Files Left";
                            ProgressUpdate?.Invoke(this, setProgressArg);
                        }
                    }
                }
                Debug.WriteLine($"Tasks marked complete in total {taskAmountComplete}");
                // Delete all marked for deletion
                taskToDelete.ForEach(x => taskList.Remove(x));

                // 1 - Update task completed / initialTaskAmount
                // 10 - 4
            }
            Debug.WriteLine($"Violation Amount: {summaryViolation.Count()}");
            Debug.WriteLine($"Tasks Left: {taskList.Count()}");
            return summaryViolation;
        }

        /// <summary>
        /// Similar to InitiateScan, except it only scans given directory in database.
        /// </summary>
        /// <param name="path">Windows File Path</param>
        public async Task InitiateDirectoryScan(string directoryPath)
        {
            IntegrityDataPooler singlePooler = new(_database, directoryPath);
            List<IntegrityViolation> violationSet = await singlePooler.CheckIntegrityDirectory();
            if (violationSet.Count > 0)
            {             
                foreach (IntegrityViolation violation in violationSet)
                {
                    await Task.Run(() => _violationHandler.ViolationAlert(violation));
                }

            }
            Console.ForegroundColor = ConsoleColor.Red;
            //Debug.WriteLine($"Reactive Alert: {violation.OriginalHash} -> {violation.Hash}, Size change: {violation.OriginalSize} -> {violation.FileSizeBytes}");
            Console.ResetColor();
        }

        public int AmountSet
        {
            get
            {
                return _amountPerSet;
            }
            set
            {
                _amountPerSet = value;
            }
        }
    }
}