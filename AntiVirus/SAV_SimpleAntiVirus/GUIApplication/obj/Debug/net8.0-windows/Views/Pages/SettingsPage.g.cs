﻿#pragma checksum "..\..\..\..\..\Views\Pages\SettingsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7FD6E3D07A4E6C7AAA4A133C0D35788581302363"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GUIApplication.Helpers;
using GUIApplication.Views.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Wpf.Ui;
using Wpf.Ui.Controls;
using Wpf.Ui.Converters;
using Wpf.Ui.Markup;


namespace GUIApplication.Views.Pages {
    
    
    /// <summary>
    /// SettingsPage
    /// </summary>
    public partial class SettingsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GUI_Application;component/views/pages/settingspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Pages\SettingsPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 28 "..\..\..\..\..\Views\Pages\SettingsPage.xaml"
            ((Wpf.Ui.Controls.ToggleSwitch)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleSwitch_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 30 "..\..\..\..\..\Views\Pages\SettingsPage.xaml"
            ((Wpf.Ui.Controls.ToggleSwitch)(target)).Checked += new System.Windows.RoutedEventHandler(this.DarkModeEnabled);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\..\..\Views\Pages\SettingsPage.xaml"
            ((Wpf.Ui.Controls.ToggleSwitch)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.LightModeEnabled);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 36 "..\..\..\..\..\Views\Pages\SettingsPage.xaml"
            ((Wpf.Ui.Controls.ToggleSwitch)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleSwitch_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 38 "..\..\..\..\..\Views\Pages\SettingsPage.xaml"
            ((Wpf.Ui.Controls.ToggleSwitch)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleSwitch_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 40 "..\..\..\..\..\Views\Pages\SettingsPage.xaml"
            ((Wpf.Ui.Controls.ToggleSwitch)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleSwitch_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 42 "..\..\..\..\..\Views\Pages\SettingsPage.xaml"
            ((Wpf.Ui.Controls.ToggleSwitch)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleSwitch_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

