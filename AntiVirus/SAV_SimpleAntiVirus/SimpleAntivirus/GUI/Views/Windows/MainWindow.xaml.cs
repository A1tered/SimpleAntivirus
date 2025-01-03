﻿using SimpleAntivirus.GUI.ViewModels.Windows;
using System.ComponentModel;
using Wpf.Ui;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace SimpleAntivirus.GUI.Views.Windows
{
    public partial class MainWindow : INavigationWindow
    {

        private bool _cancelCloses;
        public MainWindowViewModel ViewModel { get; }

        public MainWindow(
            MainWindowViewModel viewModel,
            IPageService pageService,
            INavigationService navigationService
        )
        {
            ViewModel = viewModel;
            DataContext = this;
            _cancelCloses = true;

            System.Diagnostics.Debug.WriteLine("Debug setup");

            SystemThemeWatcher.Watch(this);

            InitializeComponent();
            SetPageService(pageService);

            navigationService.SetNavigationControl(RootNavigation);
        }

        #region INavigationWindow methods

        public INavigationView GetNavigation() => RootNavigation;

        public bool Navigate(Type pageType) => RootNavigation.Navigate(pageType);

        public void SetPageService(IPageService pageService) => RootNavigation.SetPageService(pageService);

        public void ShowWindow() => Show();

        public void CloseWindow() => Close();

        public void CloseWindowGracefully()
        {
            System.Diagnostics.Debug.WriteLine("Gracefully closing!!");
            _cancelCloses = false;
            base.Close();
        }

        #endregion INavigationWindow methods

        protected override void OnClosing(CancelEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("on closing trigger!!");
            // e.Cancel (true -> does not close program on close) (false -> closes program when closed)
            e.Cancel = _cancelCloses;
            this.Hide();
            base.OnClosing(e);
        }


        /// <summary>
        /// Raises the closed event.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Make sure that closing this window will begin the process of closing the application.
            Application.Current.Shutdown();
        }

        INavigationView INavigationWindow.GetNavigation()
        {
            throw new NotImplementedException();
        }

        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}
