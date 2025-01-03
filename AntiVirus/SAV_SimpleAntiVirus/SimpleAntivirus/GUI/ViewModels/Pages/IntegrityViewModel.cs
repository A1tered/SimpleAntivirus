﻿/**************************************************************************
 * File:        IntergrityViewModel.cs
 * Author:      Christopher Thompson
 * Description: Handles backend code for the Integrity Page.
 * Last Modified: 21/10/2024
 **************************************************************************/

using SimpleAntivirus.IntegrityModule.DataRelated;
using SimpleAntivirus.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SimpleAntivirus.ViewModels.Pages
{
    public class DataRow
    {
        public string DisplayDirectory { get; set; }

        public string HiddenDirectory { get; set; }
        public string Hash { get; set; }

        public DataRow(string displayDirectory, string hash, string directory)
        {
            this.DisplayDirectory = displayDirectory;
            this.HiddenDirectory = directory;
            this.Hash = hash;
        }
    }

    public partial class IntegrityViewModel : ObservableObject, INotifyPropertyChanged
    {
        public IntegrityHandlerModel integHandlerModel { get; set; }
        private string _progressDefiner;
        private string _progressInfo;
        private bool _scanInUse;
        // Config section
        private ObservableCollection<DataRow> _datasetDirHash;
        private List<string> _pathSelected;
        private bool _allSelected;

        private string _addProgress;

        public IntegrityViewModel(IntegrityHandlerModel model)
        {
            integHandlerModel = model;
            // We link the property change event inside the Model, so we can propagate the changes upwards. (Probably not ideal to do
            // this but I cannot be bothered with a different approach.
            integHandlerModel.IntegrityManagement.PropertyChanged += HandleInnerPropertyChange;

            _progressDefiner = "";
            _progressInfo = "";
            _scanInUse = false;
            // Whether all directories are selected for deletion.
            _allSelected = false;
            integHandlerModel.IntegrityManagement.PropertyChanged += AddProgressHandler;
            _datasetDirHash = new();
            // How much to truncate directories.
            _addProgress = "";
        }

        public async Task<int> Scan()
        { // gray the button
            _scanInUse = true;
            int result = 0;
            Progress = "";
            ProgressInfo = "";
            result = await integHandlerModel.Scan();
            // When finished, set property
            Progress = $"100% Progress";
            ProgressInfo = "";
            _scanInUse = false;
            return result;
        }

        public async Task CancelAllOperations()
        {
            await integHandlerModel.CancelAll();
        }

        // If the Model (IntegrityManagement) sends out an event, handle it and update our properties.
        void HandleInnerPropertyChange(object? sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Progress")
            {
                Progress = $"{integHandlerModel.IntegrityManagement.Progress}% Progress";
                ProgressInfo = $"{integHandlerModel.IntegrityManagement.ProgressInfo}";
            }
        }

        public bool ScanInUse
        {
            get
            {
                return _scanInUse;
            }
            set
            {
                _scanInUse = value;
            }
        }

        // Property which is binded to
        public string Progress
        {
            get
            {
                return _progressDefiner;
            }
            set
            {
                _progressDefiner = value;
                // Lets the view know something has changed.
                this.PropertyChanged(this, new PropertyChangedEventArgs("Progress"));
            }
        }

        // Property that is binded to
        public string ProgressInfo
        {
            get
            {
                return _progressInfo;
            }
            set
            {
                _progressInfo = value;
                // Lets the view know that something has changed.
                this.PropertyChanged(this, new PropertyChangedEventArgs(""));
            }
        }

        public async Task<bool> ReactiveStart()
        {
            return await integHandlerModel.StartReactiveControl();
        }

        public int DeleteItem()
        {
            // Mishap, has one item failed to be deleted?
            bool mishap = false;
            bool returnInfo = false;
            if (_pathSelected != null)
            {
                if (!_allSelected)
                {


                    foreach (string pathGet in _pathSelected)
                    {
                        returnInfo = integHandlerModel.DeleteDirectory(pathGet);
                        if (!returnInfo)
                        {
                            mishap = true;
                        }
                    }
                    if (returnInfo)
                    {
                        if (mishap)
                        {
                            return 3;
                        }
                        return 2;
                    }
                    return 1;
                }
                else
                {
                    return integHandlerModel.ClearDatabase() ? 2 : 1  ;
                }
            }
            else
            {
                // No items selected
                return 0;
            }
        }

        // Add integrity path to model.
        public async Task<bool> AddIntegrityPath(string path)
        {
            if (!_scanInUse)
            {
                _scanInUse = true;
                bool returnedBool = await integHandlerModel.AddPath(path);
                _scanInUse = false;
                return returnedBool;
            }
            return false;
        }

        // Get data entries in Model
        public ObservableCollection<DataRow> GetEntries(string searchTerm = null)
        {
            Dictionary<string, string> dirHash = integHandlerModel.GetPageSet(-1);
            ObservableCollection<DataRow> tempDataRow = new();
            bool decideAdd = true;
            foreach (KeyValuePair<string, string> set in dirHash)
            {
                decideAdd = true;
                if (searchTerm != null)
                {
                    if (!set.Key.Contains(searchTerm))
                    {
                        // Don't add if it doesn't contain search term.
                        decideAdd = false;
                    }
                }
                if (decideAdd)
                {
                    tempDataRow.Add(new DataRow(FileInfoRequester.TruncateString(set.Key), set.Value, set.Key));
                }
            }
            DataEntries = tempDataRow;
            return tempDataRow;
        }

        public List<string> PathSelected
        {
            get
            {
                return _pathSelected;
            }
            set
            {
                _pathSelected = value;
            }
        }
        public ObservableCollection<DataRow> DataEntries
        {
            get
            {
                return _datasetDirHash;
            }
            set
            {
                _datasetDirHash = value;
                //this.PropertyChanged(this, new PropertyChangedEventArgs("DataEntries"));
            }
        }

        // Event updater
        private void AddProgressHandler(object? sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "AddProgress")
            {
                AddProgress = $"{Math.Round(integHandlerModel.IntegrityManagement.AddProgress, 2)}%";
            }
        }

        public bool AllSelected
        {
            get
            {
                return _allSelected;
            }
            set
            {
                _allSelected = value;
            }
        }

        public string AddProgress
        {
            get
            {
                return _addProgress;
            }
            set
            {
                _addProgress = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("AddProgress"));
            }
        }
        // This event indicates to the binding that value has changed.
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
