   M S B A M L   `   `   `  ����J  FSimpleAntivirus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SimpleAntivirus.GUI.Views.PagesSimpleAntivirus.GUI.Views.Pages  5      I)clr-namespace:SimpleAntivirus.GUI.HelpersSimpleAntivirus.GUI.Helpers  5      1    +SimpleAntivirus.GUI.Views.Pages.ScannerPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:SimpleAntivirus.GUI.Views.Pages     5      =helpers)clr-namespace:SimpleAntivirus.GUI.Helpers     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5	        N� Title$  ScannerPage��5
         ApplicationBackgroundBrush  Wpf.Ui.Markup.Design   
Background# �   5        TextFillColorPrimaryBrush   
Foreground# �  5       N� 
Foreground# �  5      $	��652��5       � 	Resources 5        BoolToVisibilityConverter9   3SimpleAntivirus.GUI.Helpers.InverseBooleanConverter  InverseBooleanConverterE   ?SimpleAntivirus.GUI.Helpers.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter��%W   &	       &	      &	 &     �� 5   
   6'     5   
   6*     5   
   66   5      .��5      �� $��0,0,0,10q�6   .+�5   
     Wpf.Ui.Controls.TextBlock  $��	0,10,0,20q�6   $
��Wrap=�6*   $O��IRun either a quick scan, full scan or custom scan with the options below.��6>   $	��Top=�6�   $
��Left=�6�   $��20(�6�   y�6�   �� *IsScanRunning+ �� 	Converter# [ 	� 5   
   -   5         	�Name$ QuickScanButton��5      $��
Quick scan��6/   $
��Left=�6D    d� 	IsChecked$
 TrueY�6_   {�6p   �� *IsScanRunning+# [ y�6�   �� *IsScanRunning+# [   5   
   $
��Wrap=�6   $:��4Scans folders where threats are most commonly found.��6+   $��0,0,0,7q�6g   y�6x   �� *IsScanRunning+# [ 	� 5   
   -   5        $ FullScanButton��5      $��	Full scan��6.   {�6B   �� *IsScanRunning+# [ y�6�   �� *IsScanRunning+# [   5   
   $
��Wrap=�6   $j��dScans all files and programs on this PC. Depending on your system, this scan may take several hours.��6+   $��0,0,0,10q�6�   y�6�   �� *IsScanRunning+# [ 	� 5   
   -   5        $ CustomScanButton��5      $��Custom scan��60   {�6�   �� *IsScanRunning+# [ y�6�   �� *IsScanRunning+# [   5    
   $
��Wrap=�6   $&�� Choose specific folders to scan.��6+   $��0,0,0,10q�6S   y�6e   �� *IsScanRunning+# [   Wpf.Ui.Controls.Button  5!   
   -   5          Name$ 	AddFolder��5!      $��
Add Folder��6'   $	��Top=�6T   $��30��6l   $��11(�6x   $
��Bold"�6�   ���	#FF2204B8���	#E4FFFFFF	   MouseOverBackground	 �	#80476EE9$��0,0,0,10q�6L  y�6�   �� *IsAddFolderButtonVisible+# [ 6L    5"   
   -   5        $��Scan now��5"      $��30��6@   $��11(�6L   $
��Bold"�6Z   ���	#FF2204B8���	#E4FFFFFF	 �	#80476EE9$��0,0,0,20q�6w  {�6�   �� *IsScanRunning+# [ y�6  �� *IsScanRunning+# [ 6w  )  #Wpf.Ui.Controls.DynamicScrollViewer  5#   
   $	��119��6!   .��5$      "  Wpf.Ui.Controls.CardExpander  $��View selected folders��6   $	��997��6�   y�6=   �� *IsCustomListVisible+# [ .��5%        $
��Wrap=�6   ��63   �� *CustomScanText+y�6S   �� *IsCustomListVisible+# [ 5&      5'      "  Wpf.Ui.Controls.ProgressRing  5(   
   
 J� RenderTransformOrigin$
 0.5,0.5&�6   $��Center=�6:   $��0,0,0,20q�6W   ���	#FF2204B8y�6�   �� *IsScanRunning+# [ z�5)   
   V� 5*      .~�5+      �� �� 5,      �� 5-      -   5        
rotateRing�� �� Angle$ 0Q�5-   :   T� 5.      5/       � Triggers 52      :� 53       :� RoutedEvent$ ui:ProgressRing.Loaded��6   .[�54      �� .��55      �� .��56      W�  �� 
TargetName$ 
rotateRing��57   !    �� TargetProperty$ Angle�58   !    W� From 059   !   	 W� To 3605:   !    g� Duration$ 0:0:1D�5;   !    g� RepeatBehavior$ Forever��5<   !   5=      5>      5?      5A        5B   
   $
��Wrap=�6   $��20(�6+   $��Scanning...��69   $��Center=�6L   y�6i   �� *IsScanRunning+# [   5C   
   $
��Wrap=�6   $��20(�6+   $��Center=�6X   ��69   �� *StopwatchText+y�6u   �� *IsScanRunning+# [   5D   
   -   5        $��Cancel��5D      $��30��6D   $��11(�6P   $
��Bold"�6^   ���#ba1111���	#E4FFFFFF
	 �����$��Center=�6  $��0,5,0,0q�66  y�6�   �� *IsScanRunning+# [ 66  5E      5F      