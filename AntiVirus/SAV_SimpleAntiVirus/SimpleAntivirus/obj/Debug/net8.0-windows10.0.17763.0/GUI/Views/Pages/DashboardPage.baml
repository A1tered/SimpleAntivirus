   M S B A M L   `   `   `  ����J  FSimpleAntivirus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SimpleAntivirus.GUI.Views.PagesSimpleAntivirus.GUI.Views.Pages  5      3    -SimpleAntivirus.GUI.Views.Pages.DashboardPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:SimpleAntivirus.GUI.Views.Pages     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      -   5          N� Title$  DashboardPage��5	         ApplicationBackgroundBrush  Wpf.Ui.Markup.Design   
Background# �   5        TextFillColorPrimaryBrush   
Foreground# �  5       N� 
Foreground# �  5       � 	Resources 5        BoolToVisibilityConverter��%   &	       �� 5   
   6'   5      .��5      �� .+�5   
     Wpf.Ui.Controls.Image  $	��100��6      Source$S Mpack://application:,,,/SimpleAntivirus;component/GUI/Resources/atriskdark.png��6x   $	��694��6�   $
��Left=�6�   y�6    �� *
AtRiskDark+ �� 	Converter# [ 6�     5   
   $	��100��6   $T Npack://application:,,,/SimpleAntivirus;component/GUI/Resources/atrisklight.png��6y   $	��690��6�   $
��Left=�6�   y�6    �� *AtRiskLight+# [ 6�     5   
   $	��100��6   $Z Tpack://application:,,,/SimpleAntivirus;component/GUI/Resources/potentialriskdark.png��6   $
��Left=�6�   $	��690��6�   y�6    �� *PotentialRiskDark+# [ 6�     5   
   $	��100��6   $[ Upack://application:,,,/SimpleAntivirus;component/GUI/Resources/potentialrisklight.png��6�   $	��692��6�   $
��Left=�6�   y�6    �� *PotentialRiskLight+# [ 6�     5   
   $	��100��6   $V Ppack://application:,,,/SimpleAntivirus;component/GUI/Resources/protecteddark.png��6{   $	��690��6�   $
��Left=�6�   y�6    �� *ProtectedDark+# [ 6�     5   
   $	��100��6   $W Qpack://application:,,,/SimpleAntivirus;component/GUI/Resources/protectedlight.png��6|   $	��690��6�   $
��Left=�6�   y�6    �� *ProtectedLight+# [ 6�     Wpf.Ui.Controls.TextBlock  5   
   $
��Wrap=�6   $
��Left=�6R   $��14(�6m   ��6+   �� *QuarantinedItemsCount+6m     5   
   $
��Wrap=�6   $
��Left=�6R   $��14(�6m   ��6+   �� *WhitelistedItemsCount+6m     Wpf.Ui.Controls.Button  5    
   -   5        $��2��5       $!��View quarantined items list��6%   $��0,10,0,0q�6K   $	��Top=�6]   $
��Left=�6u   ���	#FF2204B8���	#E4FFFFFF   MouseOverBackground �	#80476EE9$
��Bold"�6�   $��32��6  $	��204��6    5!   
   $
��Wrap=�6   $��14(�6+   $
��Left=�6[   $��0,25,0,0q�6v   ��69   �� *LastScanDateTime+6v     5"   
   $
��Wrap=�6   $��14(�6M   $
��Left=�6[   ��6+   �� *LastScanDuration+6[     5#   
   -   5        $��
Run a scan��5#      $��0,10,0,0q�6)   $	��Top=�6;   $
��Left=�6S   ���	#FF2204B8���	#E4FFFFFF �	#80476EE9$
��Bold"�6�   $��32��6�   $��94��6�     5$   
   $
��Wrap=�6   $
��Left=�6K   $��14(�6f   $��0,25,0,0q�6t   ��6+   �� *ThreatsLast24h+6t     5%   
   $
��Wrap=�6   $
��Left=�6W   $��14(�6r   ��6+   �� *IntegrityViolationsLast24h+6r     5&   
   $
��Wrap=�6   $
��Left=�6R   $��14(�6m   ��6+   �� *TerminalAlertsLast24h+6m     5'   
   -   5        $��1��5'      $��View protection history��6$   $��0,10,0,0q�6F   $	��Top=�6X   $
��Left=�6p   ���	#FF2204B8���	#E4FFFFFF �	#80476EE9$
��Bold"�6�   $��32��6  $	��179��6  "  Wpf.Ui.Controls.ToggleSwitch  5(   
   -   5          Name$ ThemeSwitch��5(      	 d� 	IsChecked$	 FalseY�6f   $��Light theme enabled��6x   $��8,6,0,0q�6�   $��Bottom=�6�   $��Center=�6�   $��0,50,0,0q�6�   5)      5*      