   M S B A M L   `   `   `  ����K  GPersonalExpenses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PersonalExpensesPersonalExpenses  5   	   I)clr-namespace:PersonalExpenses.PropertiesPersonalExpenses.Properties  5   	   b ^Syncfusion.SfChart.WPF, Version=18.1460.0.46, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89eGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPFSyncfusion.UI.Xaml.Charts 5   	   !    PersonalExpenses.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PersonalExpenses     5   	   :Resx)clr-namespace:PersonalExpenses.Properties     5   	   YchartGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPF     5   	   -   5        +   %PersonalExpenses.Properties.Resources    appName � Title# Z  5   	   $	��510��63   $	��700��6@   .��5      � .+�5   
   �� $��0,57,0,3q�6    �� Orientation$ Vertical=�6'   .+�5      �� $	��411��6   $	��660��6&   .@�5      ��    manage_expenses#��Z 6   .��5      � ���	#FFE5E5E5$��0,-1,0.4,-0.4q�62    � ColumnDefinitions 5      �� 5      $
��157* �6/   �� 5      $
��497* �6/    � RowDefinitions 5      �� 5      $	��47* �6,   �� 5      $
��299* �6,   �� 5      $	��36* �6,   .+�5      �� -   5         ��Name$ 	Lst_dates��5   "   $
��Left=�65   $	��292��6P   $	��Top=�6]   $	��145��6u   $��11,4,0,0q�6�   $��1��6�   ��5       �� 5!   "   .R�5"   &   �� $	��0,4q�60   �� 6>   $��	ExtraBold"�6_   �6B   �� *CurrentDate+6_   �� 6x   �� 6�      amount_spent#�Z 6�   �� 6�   $� ��6�   �� 6�   $
��Bold"�6�   �6�   �� *Amount+6�   6�   5#   #   5%      �� 5(      $��24,129,28,0q�6%   $ Vertical=�6:   $��1��6Q   $��1��6^   .+�5*      &   System.Windows.Controls.DataGrid  -   5          Name$ Lst_expenses��5*   8   $��2,2,2,2q�6'   	   AutoGenerateColumns	 .  $	��164��6j   
   Columns
 5+   "   0  *System.Windows.Controls.DataGridTextColumn  5-   &   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 235 69      Title   Header# Z 6E   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6n   �� *Title+  5.   &   $	 120 69      Category# Z 6E    6q   �� *
Category+  5/   &   $ 78 69      Amount# Z 6D    6n   �� *Amount+52      56      �� 5:      $
��Left=�6d   $	��114��6   $��27,2,0,0q�6�   $	��Top=�6�   $	��258��6�   $��1��6�   $��1��6�    � DataContext 6%   �� *SelectedItem+ �� ElementName$ Lst_expenses��.+�5;      �� $ 
Horizontal=�6)   $��1,1,1,1q�6B   .+�5<   "   �� $
��Wrap=�6,      Date#��Z 6@   $	��Top=�6f   $��16��6   $��1��6�   $��1��6�   $��0,5,0,5q�6�   $��68��6�   (  "System.Windows.Controls.DatePicker  5=   "   -   5          Name$ calender��5=   6      Text$ d��6-   $��1��6�   $��1��6�   $��20��6�   $	��169��6�   $��Right=�6�      SelectedDate 6H   �� *
Datetime+6�   5>      �� 5?      $ 
Horizontal=�6)   $��
0,5,-0.4,5q�6B   .+�5@   "   �� $
��Wrap=�6,   #��Z 6@   $��69��6g   �� 5A   "   -   5         ��Name$ expTitle��5A   a    �� TextWrapping$
 Wrap=�6A   $	��169��6U   ��6*   �� *Title+6a   5B      �� 5C      $ 
Horizontal=�6)   $��
0,5,-0.4,5q�6B   .+�5D   "   �� $
��Wrap=�6,   #��Z 6@   $��69��6h   �� 5E   "   -   5        $ 	expAmount��5E   b   $
 Wrap=�6B   $	��169��6V   ��6*   �� *Amount+6b   5F      �� 5G      $��21��6)   $ 
Horizontal=�65   $��
0,5,-0.4,5q�6N   .+�5H   "   �� $
��Wrap=�6,   #��Z 6@   $��69��6j   �� 5I   "   -   5         ��Name$ cbx_category��5I   +   $��20��6c   $	��169��6o    �� SelectedItem 6A   �� *
Category+6o   5J      5K      �� 5L      $��306,83,29,179q�6%   $ 
Horizontal=�6<   $��1��6U   $��1��6b   .+�5M      �� -   5        $��5,8,5,9q�5M   %   $��20��66   
   add#��Z 6B   $��75��6j   6u   �� 5N      -	   5        $��20��5N   &      delete#��Z 62   $��75��6]   $��0,8,0,9q�6�   5O      �� 5R      $��1��6%   $��372,5,25,10q�65   $ 
Horizontal=�6J   $��2��6c   .+�5S      �� $��1q�6(   $
��Left=�63   $
��Wrap=�6N      total#��Z 6b   $��42��6�   �� 5T      -
   5        $ selectedTotalAmount��5U   &   $
 Wrap=�5T   &   $��50��6:   $��	1,1,1,0.8q�6E   5U   &   5X      �� 5Y      $��1��6d   $��
27,9,227,0q�6t   $ Vertical=�6�    6%   �� *SelectedItem+$ Lst_expenses��.+�5Z      �� -   5         ��Name$ displayDate��5[   (   $
��Bold"�5Z   (   $��20(�6:   $��25��6H   $��0,9,5,0q�5[   =   5^      �� 5_      $��11,8,1,3q�6%   $ Vertical=�67   .+�5`      �� $
��Wrap=�6(       Enter_date_to_filter_list#��Z 6<   $��1,0,0,0q�6w   
�������$��9(�6�   $��14��6�   �� 5c      -   5        $ 
Tbx_filter��5c   &   $��23��6:   $
 Wrap=�6F   $	��Top=�6Z   $
��Left=�6r   $	��145��6�   &    enter_date_in_mm_dd_yyyy_format! � ToolTip#! Z  6�   6�   5d      5g      5h      �� 5j      "   all_transactions#��Z" 6   $��22��6N   $��Bottom=�6Z   .��5k      � ���	#FFE5E5E5.+�5l      �� .+�5m        -   5        $ Lst_totalexpenses��5m   '   	 .  $	��290��6_   $��27,70,39,20q�6l   
 5n   "     5p   &   $ 70 69   # Z 6D    6l   �� *
Datetime+  5q   &   $	 250 69   # Z 6E    6n   �� *Title+  5r   &   $ 90 69   # Z 6D    6p   �� *
Category+  5s   &   $ 57 69   # Z 6D    6n   �� *Amount+5v      5w      �� 5x      $��234,10,318,326q�6%   $ Vertical=�6=   .+�5y      �� $
��Left=�6(   $
��Wrap=�6C   $��To��6W   $	��Top=�6a   $��40,0,0,0q�6y     5z      -   5        $ toDateFilter��5z   \   $
��Left=�6)   $	��Top=�6D   6\   5{      �� 5|      $��29,10,523,326q�6%   $ Vertical=�6<   .+�5}      �� $
��Wrap=�6(   $
��From��6<   $	��Top=�6H   $��	32,0,35,0q�6`   # J� RenderTransformOrigin$# 1.938,-1.096&�6s     5~      -   5        $ fromDateFilter��5~   2   $ d��6)   $
��Left=�6J   $	��Top=�6e   5      �� 5�      -   5        $ ��Name$$ btn_expenseDateFilter��5�   �   $��Filter��6!   $
��Left=�62   $	��Top=�6M   $��75��6e   $��
146,26,0,0q�6p   $��24��6�   6�   5�      5�      �� 5�      %   graph#��Z% 6   .��5�      � ���	#FFE5E5E5.+�5�      �� $��
0,26,0,332q�6%   $ Vertical=�69   .+�5�        -   5        $ chartStartDate��5�   :   $��Center=�5�   )   $	��Top=�6F   $��23��6^   $ Select Start Date��5�   !   6R   '  !Syncfusion.UI.Xaml.Charts.SfChart  5�      &   PrimaryAxis& 5�   "   ,	  &Syncfusion.UI.Xaml.Charts.CategoryAxis	  5�   &   '   SecondaryAxis' 5�   "   -
  'Syncfusion.UI.Xaml.Charts.NumericalAxis
  5�   &   5�      5�      5�      5�      5�      5�      �� 5�   
   -   5        $ CoBx_language��5�      $	��Top=�6*   $��599,10,20,0q�6B   6W   5�      5�      