﻿/**************************************************************************
 * File:        IntegrityManagement.cs
 * Author:      Christopher Thompson, etc.
 * Description: Initiate scans, provide functions for outer module callers.
 * Last Modified: 21/10/2024
 **************************************************************************/

using SimpleAntivirus.IntegrityModule.Alerts;
using SimpleAntivirus.IntegrityModule.DataTypes;
using SimpleAntivirus.IntegrityModule.IntegrityComparison;
using SimpleAntivirus.IntegrityModule.Reactive;
using System.ComponentModel;
using SimpleAntivirus.Alerts;
using SimpleAntivirus.IntegrityModule.Interface;

namespace SimpleAntivirus.IntegrityModule.ControlClasses
{
    public class IntegrityManagement : IIntegrityManagement
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private IntegrityConfigurator _integrityConfigurator;
        private IntegrityCycler _integrityCycler;
        private ReactiveControl _reactiveControl;
        private double _progress;
        private double _addProgress;
        private string _progressInfo;
        private EventBus _eventbus;
        public IntegrityManagement(IIntegrityDatabaseIntermediary integrityIntermediary)
        {
            _integrityConfigurator = new IntegrityConfigurator(integrityIntermediary);
            ViolationHandler tempHandler = new();
            integrityIntermediary.DataAddProgress += ProgressUpdateAddHandler;
            tempHandler.AlertFlag += AlertHandler;
            _integrityCycler = new IntegrityCycler(integrityIntermediary, tempHandler);
            _integrityCycler.ProgressUpdate += ProgressUpdateHandler;
            _reactiveControl = new(integrityIntermediary, _integrityCycler);
            _progressInfo = "";
        }

        /// <summary>
        /// Starts ReactiveControl so that it starts responding to events on the system.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> StartReactiveControl()
        {
            return await Task.Run(() => _reactiveControl.Initialize());
        }

        /// <summary>
        /// When triggered, sends alert to GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="alertInfo"></param>
        private async void AlertHandler(object? sender, AlertArgs alertInfo)
        {
   
            System.Diagnostics.Debug.WriteLine("Alert Handler Event Triggered Successfully");
            if (_eventbus != null)
            {
                await _eventbus.PublishAsync(alertInfo.Component, alertInfo.Severity, alertInfo.Message, alertInfo.SuggestedAction);
            }
        }


        // Alert Handler to be placed here at later date.

        /// <summary>
        /// Start scanning all data in database, and compare to system files.
        /// </summary>
        /// <param name="benchmark">Whether to return debug time taken for scan</param>
        /// <returns></returns>
        public async Task<List<IntegrityViolation>> Scan(bool benchmark = false)
        {
            return await _integrityCycler.InitiateScan();
        }

        // Get how many pages would exist.
        public int GetPages()
        {
            return _integrityConfigurator.GetPageAmount();
        }

        // Get a page of entries, to be utilised by GUI. Each page will return about 10 sets. 
        public Dictionary<string, string> BaselinePage(int page)
        {
            return _integrityConfigurator.GetPage(page);
        }

        /// <summary>
        /// Add path to integrity database
        /// </summary>
        /// <param name="path">Directory</param>
        /// <param name="debug">Whether to send info to console</param>
        /// <returns></returns>
        public async Task<bool> AddBaseline(string path, bool debug = false)
        {
           bool success = await _integrityConfigurator.AddIntegrityDirectory(path, debug);
            if (success)
            {
                // If integrity items were successfully added, then add to reactive control. (As it was not initialized with the database).
                await _reactiveControl.Add(path);
            }
            return success;
        }

        /// <summary>
        /// Remove path from integrity database (Execution of this function should be moderated)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool RemoveBaseline(string path)
        {
            bool boolGet = _integrityConfigurator.RemoveIntegrityDirectory(path);
            _reactiveControl.Remove(path);
            return boolGet;
        }

        /// <summary>
        /// Remove all contents of database, via the IntegrityTrack table.
        /// Function calls to this should be moderated.
        /// </summary>
        /// <returns></returns>
        public bool ClearDatabase()
        {
            _reactiveControl.RemoveAll();
            return _integrityConfigurator.RemoveAll();
        }

        /// <summary>
        /// Call on close up of program, ensure that database objects are dealt with.
        /// </summary>
        /// <returns></returns>
        public async Task CleanUp()
        {
            await _integrityConfigurator.CancelOperations();
            await _integrityCycler.CancelScan();
            _reactiveControl.RemoveAll();
            System.Diagnostics.Debug.WriteLine("Integrity Cleanup Finished");
        }

        /// <summary>
        /// Amount of items in each Asynchronous set.
        /// </summary>
        /// <param name="amount">Amount of items in a set, must be positive.</param>
        public void ChangeSetAmount(int amount)
        {
            _integrityCycler.AmountSet = amount;
        }

        private void ProgressUpdateHandler(object? sender, ProgressArgs progressData)
        {
            Progress = progressData.Progress;
            ProgressInfo = progressData.ProgressInfo;
            //Console.Write($"Progress: {Progress}");
            //Console.Write("\r");
        }

        private void ProgressUpdateAddHandler(object? sender, ProgressArgs progressData)
        {
            // Prevent infinity.
            if (progressData.Progress > 100)
            {
                AddProgress = 0;
            }
            AddProgress = progressData.Progress;
            //Console.Write($"Progress: {Progress}");
            //Console.Write("\r");
        }

        public double AddProgress

        {
            get
            {
                return _addProgress;
            }
            set
            {
                this?.PropertyChanged(this, new PropertyChangedEventArgs("AddProgress"));
                _addProgress = value;
            }
        }

        public double Progress

        {
            get
            {
                return _progress;
            }
            set
            {
                this?.PropertyChanged(this, new PropertyChangedEventArgs("Progress"));
                _progress = value;
            }
        }

        public string ProgressInfo
        {
            get
            {
                return _progressInfo;
            }
            set
            {
                _progressInfo = value;
            }
        }

        public EventBus EventSocket
        {
            get
            {
                return _eventbus;
            }
            set
            {
                _eventbus = value;
            }
        }
    }
}
