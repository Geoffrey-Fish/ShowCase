   M S B A M L   `   `   `  ����L  HCatLitterMoneyBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CatLitterMoneyBox.ViewCatLitterMoneyBox.View  5   	   G(clr-namespace:CatLitterMoneyBox.CommandsCatLitterMoneyBox.Commands  5   	   G(clr-namespace:CatLitterMoneyBox.ControlsCatLitterMoneyBox.Controls  5   	   (    "CatLitterMoneyBox.View.HistoryView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CatLitterMoneyBox.View     5   	   =commands(clr-namespace:CatLitterMoneyBox.Commands     5   	   =controls(clr-namespace:CatLitterMoneyBox.Controls     5   	   
�������  � Title$  HistoryView��5   	   $	��450��6   $	��600��6+    � 	Resources 5      6   0CatLitterMoneyBox.Commands.ColorToBrushConverter   ColorToBrushConverter �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%*  &	        '��        5   
   6)   �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 ��  �6+   �� 5       � ��$ 12(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 80��6)   �� 5       � ��$	 120��6)   �� 5       � ��$ 30��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 10��6!   #��z��63   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5!      5"      5$      .��5%      �� 
�����_�$��5q�6%   $ 10��5&      $��5q�6   ._�5(   
   � -   5        $��MainGrid��5(      $��10q�6    � ColumnDefinitions 5)      �� 5*      $��5* �6   �� 5+      $��2* �6    � RowDefinitions 5-      �� 5.      $
��Auto �6   �� 5/      $��* �6   .+�53   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dataGrid��53   0   $��0��6   $��0��6    
   AutoGenerateColumns$

 True��55      $	��250��6.   ��54      �� *CurrentData+55   .   � 58   
   -   5        $��InfopanelGrid��58      $��0��6$   $��1��61   $��5q�6A   
������� 59   
   �� 5:      $��* �6   �� 5;      $��* �6    5=   
   �� 5>      $��* �6$   �� 5?      $��* �6$   �� 5@      $��* �6$   �� 5A      $��* �6$   �� 5B      $��* �6$   �� 5C      $��* �6$   .+�5E   
   �� $��0��6   $��2��6   $��Platz für random Text��61   �� 5F      $��1��6   $��5��6)   $��2��6:   $��WrapWithOverflow=�6N   $����Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. ��6n   6M  5G      � 5J   
   -   5        $��Controls��5J      $��1��6   $��2��6,   $��5q�6@    5K      �� 5L      $��* �6#   �� 5M      $��* �6#   �� 5N      $��* �6#    5P      �� 5Q      $��* �6    �� 5R      $��* �6    �� 5S      $��* �6    �� 5T      $��* �6    .+�5W      �� $��0��6   $��0��6!   $��Nutzerauswahl��61   $��Center=�6I   $
��Bold"�6f   $��Center=�6x   �� 5Y      -   5        $��AccountList_drpdwn��5Y   4   $��1��6   $��0��6$   $��20��6N   $	��100��6Z    �� DisplayMemberPath$
 Name��5Z   :   ��6   �� *AllDataItems+ �� SelectedItem 6S   �� *SelectedUser+�� 5\      -   5        $��Verdienst_btn��5\   2   $��0��6   $��1��6"   $��90��6G   $��20��6R   $��	Verdienst��5]      5   /CatLitterMoneyBox.Controls.ColorChangingOnClick$   IsColorChangingOnClickEnabled$
 True��5^         TemporaryColor$ darkgray��5_         OriginalColor$ 	lightgray��5`      5a      �� 5c      -   5        $��Lottery_btn��5c   2   $��0��6   $��2��6"   $��90��6E   $��20��6P   $��Lottery��5d      $
 True��5e      $ darkgray��5f      $ 	lightgray��5g      5h      �� 5j      -   5        $��
Payout_btn��5j   2   $��1��6   $��1��6"   $��90��6D   $��20��6O   $��Auszahlungen��5k      $
 True��5l      $ darkgray��5m      $ 	lightgray��5n      5o      �� 5q      -	   5        $��Richest_btn��5q   2   $��1��6   $��2��6"   $��90��6E   $��20��6P   $��König��5r      $
 True��5s      $ darkgray��5t      $ 	lightgray��5u      5v      5w      5x      5y      5z      