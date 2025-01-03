﻿/**************************************************************************
 * File:        SplitProcess.cs
 * Author:      Joel Parks
 * Description: Handles the creation of hunters to do scanning, sets up directories for scanning.
 * Last Modified: 21/10/2024
 **************************************************************************/

namespace SimpleAntivirus.FileHashScanning
{
    public class SplitProcess
    {
        private List<string> _directoryViolations;
        private Stack<string> _directoryRemnants;
        private List<Hunter> _hunterUnits;
        private List<Task> _taskUnits;
        private int _directoriesSearched;

        private readonly string _databaseDirectory;
        private readonly FileHashScanner _scanner;
        private readonly CancellationToken _token;

        /// <summary>
        /// The start of the directory unpacking process.
        /// 
        /// Spawns hunters that find directories and return their results, cycles this multiple times until
        /// no more directories are to be unpacked. 
        /// 
        /// </summary>
        /// <param name="databaseDirectory"></param>
        public SplitProcess(string databaseDirectory, FileHashScanner scanner, CancellationToken token)
        {
            _directoryViolations = new();
            _directoryRemnants = new();
            _hunterUnits = new();
            _taskUnits = new();
            _scanner = scanner;
            _databaseDirectory = databaseDirectory;
            _token = token;

            // Statistics
            _directoriesSearched = 0;
        }

        public async Task SearchDirectory()
        {
            // OPTIONS THAT DIRECTLY AFFECT PERFORMANCE!!!
            // How many asynchronous directory readers can run in a cycle (More > system use is heavier)
            // default 500
            int hunterCreationLimit = 500;
            // (ms millisecond time) How long to wait for asynchronous tasks, will keep tasks in next cycle if going over.
            // default 1000
            int taskWaitTime = 1000;
            // temp vars
            int removedTasks;
            int totalTasks;
            while (_directoryRemnants.Count > 0 || _taskUnits.Count > 0)
            {
                // Max at hunter units - task units.
                for (int i = 0; i < Math.Min(_directoryRemnants.Count, hunterCreationLimit - _taskUnits.Count()); i++)
                {
                    _hunterUnits.Add(new Hunter(_directoryRemnants.Pop(), _databaseDirectory, _token));
                }
                // Remove items from directory remnants (based on how many hunters)
                foreach (Hunter hunter in _hunterUnits)
                {
                    _taskUnits.Add(hunter.SearchDirectory(_scanner));
                }
                _hunterUnits.Clear();
                totalTasks = _taskUnits.Count();
                // wait all thing here, they should return more directories
                await Task.WhenAll(_taskUnits);
                foreach (Task<Tuple<string[], string[]>> task in _taskUnits)
                {
                    if (task.IsCompleted)
                    {
                        _directoriesSearched++;
                        await UnpackTuple(task.Result);
                    }
                }
                // Remove all completed tasks
                removedTasks = _taskUnits.RemoveAll(task => task.IsCompleted == true);
            }
        }

        private async Task UnpackTuple(Tuple<string[], string[]> tuple)
        {
            // Hunters have new directories to search and any violations they've found via tuple.
            await Task.Run(() =>
            {
                Array.ForEach<string>(tuple.Item1, _directoryViolations.Add);
                Array.ForEach<string>(tuple.Item2, _directoryRemnants.Push);
            });
        }

        // Initial function, to find the initial directories. This is not called other than in the initial process.
        public async Task FillUpSearch(string directory)
        {
            Hunter hunter = new Hunter(directory, _databaseDirectory, _token);
            Tuple<string[], string[]> tupleItem = await hunter.SearchDirectory(_scanner);
            await UnpackTuple(tupleItem);
        }

        public int DirectoriesSearched
        {
            get
            {
                return _directoriesSearched;
            }
        }
    }
}