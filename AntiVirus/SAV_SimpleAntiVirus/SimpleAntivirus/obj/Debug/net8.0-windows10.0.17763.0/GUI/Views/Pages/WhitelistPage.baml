   M S B A M L   `   `   `  ����J  FSimpleAntivirus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SimpleAntivirus.GUI.Views.PagesSimpleAntivirus.GUI.Views.Pages  5      I)clr-namespace:SimpleAntivirus.GUI.HelpersSimpleAntivirus.GUI.Helpers  5      3    -SimpleAntivirus.GUI.Views.Pages.WhitelistPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:SimpleAntivirus.GUI.Views.Pages     5      =helpers)clr-namespace:SimpleAntivirus.GUI.Helpers     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	      A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5
      -   5          N� Title$  WhitelistPage��5         ApplicationBackgroundBrush  Wpf.Ui.Markup.Design   
Background# �   5        TextFillColorPrimaryBrush   
Foreground# �  5       N� 
Foreground# �  5      $	��483��5       � 	Resources 5        Wpf.Ui.Controls.Button �� BasedOn �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell  BoolToVisibilityConverter9   3SimpleAntivirus.GUI.Helpers.InverseBooleanConverter  InverseBooleanConverterE   ?SimpleAntivirus.GUI.Helpers.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter��%w  '        7 '  �     &	     &	     &	 .    �� 5   
   8   "  6>   .�5      ��  � �� �	#FF2C05F26+   �� 5       � �� �	#E4FFFFFF6+   �� 5       �@ MouseOverBackground �	#80476EE964   �� 5       � ��$
 Bold"�6+   5      �� 5   
   "  6   5      �� 5   
   6'     5    
   6*     5!   
   66   5"      .��5$      �� .+�5%   
     Wpf.Ui.Controls.TextBlock  $
��Wrap=�6   $��20(�6+   $����View the currently whitelisted items and remove them from the whitelist.
If you are looking to add a file to the whitelist, please ensure the file is quarantined by first reviewing the Quarantined Items page.
Finally, select the file and choose [Add to Whitelist].��69   $��0,0,0,20q�6Q  &   System.Windows.Controls.DataGrid  5&   
   -   5        	  Name$	 WhitelistDataGrid��5&      $	��287��6.   
   AutoGenerateColumns$
 False��6;      
IsReadOnly$
 True��6W      Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ 	File Path��6%    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ *
 68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *
FilePath+5*        5+   
   -   5          Name$ SelectLabel��5+   +   $
��Wrap=�6   $��No Items Selected��6@   $��14(�6Y   $��Italic$�6g   � 5,   
   $��52��6    � ColumnDefinitions 5-      �� 5.      $��* �6#   �� 5/      $��* �6#   �� 50      $��* �6#   .+�52        -   5        $��1��52      $��Remove from Whitelist��6(   $��0,10,0,0q�6H   $	��Top=�6Z   $��Center=�6r   ���#ba1111   MouseOverBackground
 �����y�6�   �� *IsBusy+ �� 	Converter# [ 53      � 55   
   $��68��6    56      �� 57      $
��0.3* �6#   �� 58      $��* �6#   .+�5:      "  Wpf.Ui.Controls.ProgressRing  $��0��6    J� RenderTransformOrigin$ 0.5,0.5&�6.   $��Center=�6N   ���	#FF2204B8$	��Top=�6�   y�6�   �� *IsBusy+# [ z�5;      V� 5<      .~�5=      �� �� 5>      �� 5?      -   5        
rotateRing�� �� Angle$ 0Q�5?   >   T� 5@      5A       � Triggers 5D      :� 5E       :� RoutedEvent$ ui:ProgressRing.Loaded��6#   .[�5F      �� .��5G      �� .��5H   "   W�  �� 
TargetName$ 
rotateRing��5I   !    �� TargetProperty$ Angle�5J   !    W� From 05K   !   	 W� To 3605L   !    g� Duration$ 0:0:1D�5M   !    g� RepeatBehavior$ Forever��5N   !   5O      5P      5Q      5S        5T      $
��Wrap=�6   $��20(�6/   $G��APlease wait for the process to complete. This may take some time.��6=   $��1��6�   $��	0,0,245,0q�6�   $	��Top=�6�   y�6�   �� *IsBusy+# [ 6�   5U      5V      5W      