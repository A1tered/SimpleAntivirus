   M S B A M L   `   `   `  ����J  FGUI_Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GUIApplication.Views.PagesGUIApplication.Views.Pages  5      ,    &GUIApplication.Views.Pages.ScannerPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GUIApplication.Views.Pages     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5        N� Title$  ScannerPage��5	         ApplicationBackgroundBrush  Wpf.Ui.Markup.Design   
Background# �   5        TextFillColorPrimaryBrush   
Foreground# �  5       N� 
Foreground# �  5      .��5      �� .+�5   
     Wpf.Ui.Controls.TextBlock  $��	0,10,0,50q�6   $
��Wrap=�6*   $O��IRun either a quick scan, full scan or custom scan with the options below.��6>   $	��Top=�6�   $��Center=�6�   $��20(�6�   	� 5   
   -   5        $��
Quick scan��5      $
��Left=�6I    d� 	IsChecked$
 TrueY�6d     5   
   $
��Wrap=�6   $:��4Scans folders where threats are most commonly found.��6+   $��0,0,0,7q�6g   	� 5   
   -   5        $��	Full scan��5      6*     5   
   $
��Wrap=�6   $j��dScans all files and programs on this PC. Depending on your system, this scan may take several hours.��6+   $��0,0,0,10q�6�   	� 5   
   -   5        $��Custom scan��5      6,     5   
   $
��Wrap=�6   $/��)Choose specific files or folders to scan.��6+   $��0,0,0,10q�6\     Wpf.Ui.Controls.Button  5   
   -   5        $��	Scan now!��5      $��0,0,10,0q�6=   ���	#FF2204B8$��30��6f   $��11(�6r   $
��Bold"�6�   ���	#E4FFFFFF6�   5      5      