﻿using SimpleAntivirus.GUI.ViewModels.Pages;
using SimpleAntivirus.GUI.ViewModels.Windows;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace SimpleAntivirus.GUI.Views.Pages
{
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }

        public DashboardPage(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        private void DarkModeChange(ToggleSwitch toggle)
        {
            toggle.Content = "Dark theme enabled";
            ViewModel.OnChangeTheme("theme_dark");
        }

        private void LightModeChange(ToggleSwitch toggle)
        {
            toggle.Content = "Light theme enabled";
            ViewModel.OnChangeTheme("theme_light");
        }

        private void DarkModeEnabled(object sender, RoutedEventArgs e)
        {
            DashboardViewModel viewModel = new DashboardViewModel();

            if (sender is ToggleSwitch toggleSwitch)
            {
                DarkModeChange(toggleSwitch);
            }
        }

        private void LightModeEnabled(object sender, RoutedEventArgs e)
        {
            DashboardViewModel viewModel = new DashboardViewModel();

            if (sender is ToggleSwitch toggleSwitch)
            {
                LightModeChange(toggleSwitch);
            }
        }

        // On page loaded, determine the current theme and check if Dark mode is already enabled.
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            ThemeSwitch.IsChecked = true;
            if (ViewModel.CurrentTheme == Wpf.Ui.Appearance.ApplicationTheme.Dark)
            {
                DarkModeChange(ThemeSwitch);
                ThemeSwitch.IsChecked = true;
            }
            else
            {
                LightModeChange(ThemeSwitch);
            }
        }
    }
}
