   M S B A M L   `   `   `  ����J  FGUI_Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GUIApplication.Views.PagesGUIApplication.Views.Pages  5      -    'GUIApplication.Views.Pages.ScanningPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GUIApplication.Views.Pages     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5        N� Title$  ScanningPage��5	         ApplicationBackgroundBrush  Wpf.Ui.Markup.Design   
Background# �   5        TextFillColorPrimaryBrush   
Foreground# �  5       N� 
Foreground# �  5      .��5      �� .+�5   
     Wpf.Ui.Controls.TextBlock  $
��Wrap=�6   $��Scanning...��6+   $
��Bold"�6>   $��36(�6P   $��Center=�6^   $��	0,70,0,20q�6{   "  Wpf.Ui.Controls.ProgressRing  5   
    J� RenderTransformOrigin$ 0.5,0.5&�6   z�5      V� 5      .~�5      �� �� 5      �� 5      -   5        
rotateRing�� �� Angle$ 0Q�5   :   T� 5      5       � Triggers 5      :� 5        :� RoutedEvent$ ui:ProgressRing.Loaded��6   .[�5!      �� .��5"      �� .��5#      W�  �� 
TargetName$ 
rotateRing��5$   !   	 �� TargetProperty$	 Angle�5%   !   
 W� From
 05&   !   	 W� To 3605'   !    g� Duration$ 0:0:1D�5(   !    g� RepeatBehavior$ Forever��5)   !   5*      5+      5,      5.        5/   
   $
��Wrap=�6   $%��Scan in progress... Please wait��6+   $��24(�6R   $��Center=�6`   � 50   
   $��14��6   $	��258��6"   $��0,10,0,0q�6.     51   
   $
��Wrap=�6   $��X% complete��6+   $��24(�6>   $��Center=�6L     52   
   $
��Wrap=�6   $��Y items scanned��6+   $��24(�6B   $��Center=�6P     53   
   $
��Wrap=�6   $��Z threats found��6+   $��24(�6B   $��Center=�6P     Wpf.Ui.Controls.Button  54   
   -   5        $��Cancel scan��54      $��Center=�6>   $��0,21,0,0q�6[   ���	#FF2C05F2���	#E4FFFFFF$
��Bold"�6�   55      56      