﻿using SimpleAntivirus.GUI.Services;
using SimpleAntivirus.GUI.ViewModels.Pages;
using SimpleAntivirus.GUI.ViewModels.Windows;
using SimpleAntivirus.GUI.Views.Pages;
using SimpleAntivirus.GUI.Views.Windows;
using SimpleAntivirus.ViewModels.Pages;
using SimpleAntivirus.Models;
using SimpleAntivirus.Alerts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using Wpf.Ui;
using Microsoft.Toolkit.Uwp.Notifications;
using Wpf.Ui.Appearance;
using SimpleAntivirus.FileQuarantine;
using Windows.Devices.WiFiDirect.Services;
using Windows.UI.ViewManagement;

namespace SimpleAntivirus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        // The.NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)); })
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<ApplicationHostService>();

                // Page resolver service
                services.AddSingleton<IPageService, PageService>();

                // Theme manipulation
                services.AddSingleton<IThemeService, ThemeService>();

                // TaskBar manipulation
                services.AddSingleton<ITaskBarService, TaskBarService>();

                // Service containing navigation, same as INavigationWindow... but without window
                services.AddSingleton<INavigationService, NavigationService>();

                // Main window with navigation
                services.AddSingleton<INavigationWindow, MainWindow>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<BlacklistPage>();
                services.AddSingleton<BlacklistViewModel>();
                services.AddSingleton<DashboardPage>();
                services.AddSingleton<DashboardViewModel>();

                services.AddSingleton<IntegrityPage>();
                services.AddSingleton<IntegrityViewModel>();
                services.AddSingleton<IntegrityHandlerModel>();
                services.AddSingleton<IntegrityResultsPage>();
                services.AddSingleton<IntegrityResultsViewModel>();

                services.AddSingleton<ScannerPage>();
                services.AddSingleton<ScannerViewModel>();

                services.AddSingleton<SettingsPage>();
                services.AddSingleton<SettingsViewModel>();

                services.AddSingleton<QuarantinedItemsPage>();
                services.AddSingleton<QuarantinedViewModel>();

                services.AddSingleton<AlertManager>();
                services.AddSingleton<EventBus>();

                services.AddSingleton<ProtectionHistoryPage>();
                services.AddSingleton<ProtectionHistoryViewModel>();
                services.AddSingleton<ProtectionHistoryModel>();
                services.AddSingleton<AlertReportPage>();
            }).Build();

        /// <summary>
        /// Gets registered service.
        /// </summary>
        /// <typeparam name="T">Type of the service to get.</typeparam>
        /// <returns>Instance of the service or <see langword="null"/>.</returns>
        public static T GetService<T>()
            where T : class
        {
            return _host.Services.GetService(typeof(T)) as T;
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            _host.Start();
            NavigationServiceIntermediary.NavigationService = _host.Services.GetService<INavigationService>();

            // Rough fix to theme irregularity copied from other theme window.
            ApplicationTheme CurrentTheme = ApplicationThemeManager.GetAppTheme();
            ApplicationThemeManager.Apply(CurrentTheme);
            // Concern about async in this, however will only replace if this causes issues.
            await _host.Services.GetService<IntegrityViewModel>().ReactiveStart();
            
        }

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();
            ToastNotificationManagerCompat.History.Clear();
            _host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}
