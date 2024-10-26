﻿using SimpleAntivirus.FileQuarantine;
using SimpleAntivirus.GUI.ViewModels.Pages;
using Wpf.Ui.Controls;
using System.IO;
using System.Diagnostics;
using System.DirectoryServices;
using System.Collections.ObjectModel;
using System.Windows;

namespace SimpleAntivirus.GUI.Views.Pages
{
    public class Entry
    {
        public bool IsSelected { get; set; }
        public required string OriginalFilePath { get; set; }
        public required string QuarantineDate { get; set; }
    }

    public partial class QuarantinedItemsPage : INavigableView<QuarantinedViewModel>
    {
        public QuarantinedViewModel ViewModel { get; }
        private QuarantineManager _quarantineManager;
        private FileMover _fileMover;
        private IDatabaseManager _databaseManager;
        private ObservableCollection<Entry> _entries;

        public QuarantinedItemsPage(QuarantinedViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();
            _fileMover = new FileMover();
            _databaseManager = new DatabaseManager(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases", "quarantine.db"));
            _quarantineManager = new QuarantineManager(_fileMover, _databaseManager, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Quarantine"));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var entries = await _quarantineManager.GetQuarantinedFileDataAsync();
            _entries = new ObservableCollection<Entry>(
                entries.Select(e => new Entry
            {
                OriginalFilePath = e.OriginalFilePath,
                QuarantineDate = e.QuarantineDate,
            }).ToList());

            QuarantinedItemsDataGrid.ItemsSource = _entries;
        }

        private void QuarantinedSelected(object sender, RoutedEventArgs e)
        {
            if (QuarantinedItemsDataGrid.SelectedItem != null)
            {
                List<QuarantinedDataRow> selectedItems = QuarantinedItemsDataGrid.SelectedItems.Cast<QuarantinedDataRow>().ToList();
                int allItemCount = QuarantinedItemsDataGrid.Items.Count;
                string infoText = "";
                if (!(allItemCount == selectedItems.Count) || selectedItems.Count == 1)
                {
                    ViewModel.AllSelected = false;
                    List<string> selectedDirectories = new();
                    if (selectedItems.Count() == 1)
                    {
                        infoText = $"Selected: {selectedItems[0].OriginalDirectory}";
                    }
                    else
                    {
                        infoText = $"Selected: {selectedItems.Count()} Items";
                    }
                    // Remove final comma.
                    infoText.Remove(infoText.Length - 1, 1);
                    ViewModel.PathSelected = selectedDirectories;
                }
                else
                {
                    infoText = $"All Items Selected ({allItemCount} Items)";
                    ViewModel.AllSelected = true;
                }
                //SelectLabel.Text = infoText;
            }
            else
            {
                //SelectLabel.Text = "None Selected";
                ViewModel.PathSelected = null;
            }
        }
    }
}
