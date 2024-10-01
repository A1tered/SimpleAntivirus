﻿#pragma checksum "..\..\..\..\..\..\GUI\Views\Pages\ScannerPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ABFCD32AE6210AAD2DFD689C1964288536F2DD6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SimpleAntivirus.GUI.Helpers;
using SimpleAntivirus.GUI.Views.Pages;
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


namespace SimpleAntivirus.GUI.Views.Pages {
    
    
    /// <summary>
    /// ScannerPage
    /// </summary>
    public partial class ScannerPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\..\..\GUI\Views\Pages\ScannerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton QuickScanButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\..\GUI\Views\Pages\ScannerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton FullScanButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\..\GUI\Views\Pages\ScannerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton CustomScanButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\..\GUI\Views\Pages\ScannerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Button AddFolder;
        
        #line default
        #line hidden
        
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
            System.Uri resourceLocater = new System.Uri("/SimpleAntivirus;component/gui/views/pages/scannerpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\GUI\Views\Pages\ScannerPage.xaml"
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
            this.QuickScanButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 2:
            this.FullScanButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.CustomScanButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 32 "..\..\..\..\..\..\GUI\Views\Pages\ScannerPage.xaml"
            this.CustomScanButton.Checked += new System.Windows.RoutedEventHandler(this.CustomScanButton_Checked);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\..\..\..\GUI\Views\Pages\ScannerPage.xaml"
            this.CustomScanButton.Unchecked += new System.Windows.RoutedEventHandler(this.CustomScanButton_Unchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddFolder = ((Wpf.Ui.Controls.Button)(target));
            
            #line 40 "..\..\..\..\..\..\GUI\Views\Pages\ScannerPage.xaml"
            this.AddFolder.Click += new System.Windows.RoutedEventHandler(this.AddFolder_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 42 "..\..\..\..\..\..\GUI\Views\Pages\ScannerPage.xaml"
            ((Wpf.Ui.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ScanButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 43 "..\..\..\..\..\..\GUI\Views\Pages\ScannerPage.xaml"
            ((Wpf.Ui.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelScanButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
