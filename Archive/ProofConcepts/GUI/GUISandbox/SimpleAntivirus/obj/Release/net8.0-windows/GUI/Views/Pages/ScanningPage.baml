   M S B A M L   `   `   `  ���� J  FSimpleAntivirus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SimpleAntivirus.GUI.Views.PagesSimpleAntivirus.GUI.Views.Pages  2    ,SimpleAntivirus.GUI.Views.Pages.ScanningPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     ?local-clr-namespace:SimpleAntivirus.GUI.Views.Pages     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml    N� Title$  ScanningPage��   ApplicationBackgroundBrush  Wpf.Ui.Markup.Design   
Background# �     TextFillColorPrimaryBrush   
Foreground# �   N� 
Foreground# �  .���� .+�  Wpf.Ui.Controls.TextBlock  $
��Wrap=�$��Scanning...��$
��Bold"�$��36(�$��Center=�$��	0,70,0,20q�"  Wpf.Ui.Controls.ProgressRing   J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� -   
rotateRing�� �� Angle$ 0Q�T�  � Triggers :�  :� RoutedEvent$ ui:ProgressRing.Loaded��.[��� .���� .��W�  �� 
TargetName$ 
rotateRing��	 �� TargetProperty$	 Angle�
 W� From
 0	 W� To 360 g� Duration$ 0:0:1D� g� RepeatBehavior$ Forever��  $
��Wrap=�$%��Scan in progress... Please wait��$��24(�$��Center=�� $��14��$	��258��$��0,10,0,0q�  $
��Wrap=�$��X% complete��$��24(�$��Center=�  $
��Wrap=�$��Y items scanned��$��24(�$��Center=�  $
��Wrap=�$��Z threats found��$��24(�$��Center=�  Wpf.Ui.Controls.Button  -   $��Cancel scan��$��Center=�$��0,21,0,0q����	#FF2C05F2���	#E4FFFFFF$
��Bold"�