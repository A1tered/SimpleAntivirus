﻿#pragma checksum "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D5CC73E8F1289B1D6AB816E241653D11FC694BD0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GUISandbox.Views.Pages;
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


namespace GUISandbox.Views.Pages {
    
    
    /// <summary>
    /// IntegrityConfigurePage
    /// </summary>
    public partial class IntegrityConfigurePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataShow;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PageCount;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PreviousButton;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SelectLabel;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Button AddFile;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Button AddFolder;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.ProgressRing ProgressAdd;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.RotateTransform Rotator;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ProgressInfo;
        
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
            System.Uri resourceLocater = new System.Uri("/GUISandbox;component/views/pages/integrityconfigurepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
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
            
            #line 11 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
            ((GUISandbox.Views.Pages.IntegrityConfigurePage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DataShow = ((System.Windows.Controls.DataGrid)(target));
            
            #line 24 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
            this.DataShow.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataShow_Selected);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PageCount = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.NextButton = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
            this.NextButton.Click += new System.Windows.RoutedEventHandler(this.NextButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PreviousButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
            this.PreviousButton.Click += new System.Windows.RoutedEventHandler(this.PreviousButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 33 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SelectLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.AddFile = ((Wpf.Ui.Controls.Button)(target));
            
            #line 35 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
            this.AddFile.Click += new System.Windows.RoutedEventHandler(this.AddFile_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AddFolder = ((Wpf.Ui.Controls.Button)(target));
            
            #line 36 "..\..\..\..\..\Views\Pages\IntegrityConfigurePage.xaml"
            this.AddFolder.Click += new System.Windows.RoutedEventHandler(this.AddFolder_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ProgressAdd = ((Wpf.Ui.Controls.ProgressRing)(target));
            return;
            case 11:
            this.Rotator = ((System.Windows.Media.RotateTransform)(target));
            return;
            case 12:
            this.ProgressInfo = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

