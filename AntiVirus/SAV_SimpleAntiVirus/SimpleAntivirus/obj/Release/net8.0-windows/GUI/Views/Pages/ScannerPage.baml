   M S B A M L   `   `   `  ���� J  FSimpleAntivirus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SimpleAntivirus.GUI.Views.PagesSimpleAntivirus.GUI.Views.Pages  1    +SimpleAntivirus.GUI.Views.Pages.ScannerPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     ?local-clr-namespace:SimpleAntivirus.GUI.Views.Pages     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml    N� Title$  ScannerPage��   ApplicationBackgroundBrush  Wpf.Ui.Markup.Design   
Background# �     TextFillColorPrimaryBrush   
Foreground# �   N� 
Foreground# �  .���� .+�  Wpf.Ui.Controls.TextBlock  $��	0,10,0,50q�$
��Wrap=�$O��IRun either a quick scan, full scan or custom scan with the options below.��$	��Top=�$��Center=�$��20(�	� -    	�Name$ QuickScanButton��$��
Quick scan��$
��Left=� d� 	IsChecked$
 TrueY�  $
��Wrap=�$:��4Scans folders where threats are most commonly found.��$��0,0,0,7q�	� -   $ FullScanButton��$��	Full scan��  $
��Wrap=�$j��dScans all files and programs on this PC. Depending on your system, this scan may take several hours.��$��0,0,0,10q�	� -   $ CustomScanButton��$��Custom scan��  $
��Wrap=�$/��)Choose specific files or folders to scan.��$��0,0,0,10q�  Wpf.Ui.Controls.Button  -   $��	Scan now!��$��0,0,10,0q����	#FF2204B8$��30��$��11(�$
��Bold"����	#E4FFFFFF