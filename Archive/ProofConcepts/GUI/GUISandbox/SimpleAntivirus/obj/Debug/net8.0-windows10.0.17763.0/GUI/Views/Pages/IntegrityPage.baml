   M S B A M L   `   `   `  ����J  FSimpleAntivirus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SimpleAntivirus.GUI.Views.PagesSimpleAntivirus.GUI.Views.Pages  5      3    -SimpleAntivirus.GUI.Views.Pages.IntegrityPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:SimpleAntivirus.GUI.Views.Pages     5      A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      -   5        $��10q�5        N� Title$  IntegritPage��5
       � 	Resources 5        Wpf.Ui.Controls.Button �� BasedOn �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell��%   '        7 '  �     �� 5   
   8   "  6>   .�5      ��  � �� �	#FF2C05F26+   �� 5       � �� �	#E4FFFFFF6+   �� 5       �@ MouseOverBackground �	#80476EE964   �� 5       � ��$
 Bold"�6+   5      �� 5   
   "  6   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       .+�5"   
     -   5          Name$ IntegrityScanButton��5"      $��Integrity Scan��62   $��	0,143,0,0q�6K   $	��Top=�6^   $	��244��6v   $��32��6�   $��1��6�   $��Center=�6�     Wpf.Ui.Controls.TextBlock  5#   
   -   5        	  Name$	 InfoProvide��5#      
 �� TextAlignment$
 Center=�6,   $��Center=�6j   $��0,53,0,0q�6�   $	��Top=�6�   $	��180��6�   
������ $��31��6�   $��18(�6�   $��1��6�   ��6C   �� *
Progress+ �� Mode$ OneWay=�6�     5$   
   -   5        $	 InfoProvideDescription��5$      $
 Center=�67   $��Center=�6y   $��0,89,0,0q�6�   $	��Top=�6�   $	��180��6�   
������ $��31��6�   $��18(�6�   $��1��6�   ��6N   �� *ProgressInfo+$ OneWay=�6�     5%   
   -   5        $	 ViolationNote��5%      $
 Center=�6.   $�� ��6E   $��Center=�6M   $��	0,119,0,0q�6j   $	��Top=�6}   $	��180��6�   
������ $��19��6�   $��16(�6�   $
��Bold"�6�   $��1��6�     5&   
   -   5        $ ResultsButton��5&      $y�Hidden=�6+   $��See Results��6?   $��	0,214,0,0q�6U   $	��Top=�6h   $��1��6�   $��Center=�6�   $��32��6�   $��94��6�   "  Wpf.Ui.Controls.CardExpander  5'   
   $��0��6   $��Stretch=�6*   $	��669��6H   $!��Configure Integrity Entries��6U   $��-14,305,0,0q�6z   $	��Top=�6�   $��3��6�   $��2��6�   .��5(      �  5)      �� 5*      �� 5+       5.      �� 5/      $	��31* �6'   �� 50      $	��290��6'   $	��50* �66   �� 51      $	��31* �6'   .+�54      &   System.Windows.Controls.DataGrid  -   5          Name$ DataShow��54      $��3��6-   $��44,26,24,88q�6A      AutoGenerateColumns$ False��6V      
IsReadOnly$
 True��6r   $	��200��6�   $��1��6�      Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Directory��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6e   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6@   �� *DisplayDirectory+6e     57      $
 Hash��6-   $ * 6T    6;   �� *Hash+6T   59        5:      -   5        $ DeleteButton��5:      $��2��62   $��Delete��6B   $��
20,251,0,0q�6S   $	��Top=�6g   $��1��6�   $��32��6�   $��89��6�   ���#ba1111   MouseOverBackground
 �����6�     5;      -	   5        $	 SelectLabel��5;      $��No Item Selected��64   $
 Right=�6L   $��Right=�6b   $��	0,255,0,0q�6~   $��1��6�   $	��Top=�6�   $	��375��6�   $��23��6�   $��2��6�     5<      -
   5        $ AddFile��5<      $��1��6-   $��Right=�6=   $��Add File��6Y   $��	0,66,20,0q�6�   $	��Top=�6�   $��99��6�   $��32��6�     5=      -   5        $ 	AddFolder��5=      $��2��6/   $��
Add Folder��6?   $��	20,66,0,0q�6T   $	��Top=�6   $��97��6�   $��32��6�   "
  Wpf.Ui.Controls.ProgressRing
  5>      -   5         
 Name$ ProgressAdd��5>   "   $y�Hidden=�67    J� RenderTransformOrigin$ 0.5,0.5&�6K   $��1��6l   $��Right=�6|   $��
0,70,136,0q�6�   $	��Top=�6�   $��24��6�   $��24��6�   z�5?      �� 5@      -   5        Rotator�� �� Angle$ 0Q�5@   ;   5B      �� 5C      -   5         ��Name$ ProgressInfo��5C      $y�Visible=�6.   $��1��6C   $
��Left=�6�   $��	72,70,0,0q�6�   $	��Top=�6�   $��24��6�   $��50��6�   ��6S   �� *AddProgress+$ OneWay=�6�     Wpf.Ui.Controls.TextBox  5D      -   5          Name$ 	SearchBox��5D      $��0��60   $��Right=�6@   $��0,64,0,0q�6\    �� TextWrapping$
 Wrap=�6n   $�� ��6�      PlaceholderText$' !Search                           ��6�   $	��Top=�6�   $	��200��6�   $��36��6  5E      5F      5G      5H      