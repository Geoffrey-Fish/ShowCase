   M S B A M L   `   `   `  ���� L  HCatLitterMoneyBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CatLitterMoneyBox.ViewCatLitterMoneyBox.View  G(clr-namespace:CatLitterMoneyBox.CommandsCatLitterMoneyBox.Commands  G(clr-namespace:CatLitterMoneyBox.ControlsCatLitterMoneyBox.Controls  (    "CatLitterMoneyBox.View.HistoryView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:CatLitterMoneyBox.View     =commands(clr-namespace:CatLitterMoneyBox.Commands     =controls(clr-namespace:CatLitterMoneyBox.Controls     
�������  � Title$  HistoryView��$	��450��$	��600�� � 	Resources 6   0CatLitterMoneyBox.Commands.ColorToBrushConverter   ColorToBrushConverter �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%4  &	        '��        �� " ��.���  � ��
 �������  � ��
 ��� ���  � ��$ 12(���  � ��$
 Bold"���  � ��$
 10,5q���  � ��$ 80����  � ��$	 120����  � ��$ 30����  � �� �� " ��.R��� $ 10��#��z��._��� $��Center=�$��Center=�.���� 
�����_�$��5q�$ 10��$��5q�._�� -   $��MainGrid��$��10q� � RowDefinitions �� $
��Auto ��� $��* �.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$��0��$��0��	   AutoGenerateColumns$
	 True��$	��250������ *CurrentData+� -   $��Controls��$��1��$��5q�
 � ColumnDefinitions
 �� $��* ��� $��* � �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��0��$��Nutzerauswahl��$��Center=�$
��Bold"�$��Center=��� -   $��AccountList_drpdwn��$��0��$��1��$��20��$	��100�� �� DisplayMemberPath$
 Name������ *Names+ �� SelectedItem �� *SelectedUser+�� -   $��Verdienst_btn��$��1��$��0��$��90��$��20��$��	Verdienst��5   /CatLitterMoneyBox.Controls.ColorChangingOnClick$   IsColorChangingOnClickEnabled$
 True��   TemporaryColor$ darkgray��   OriginalColor$ 	lightgray���� -   $��Lottery_btn��$��2��$��0��$	��120��$��20��$��Lotteriegewinner��$
 True��$ darkgray��$ 	lightgray���� -   $��
Payout_btn��$��1��$��1��$��90��$��20��$��Auszahlungen��$
 True��$ darkgray��$ 	lightgray���� -   $��Richest_btn��$��2��$��1��$��90��$��20��$��Hamster��$
 True��$ darkgray��$ 	lightgray���� -	   $��	Reset_btn��$��3��$��0��$��90��$��20��$��Reset��$
 True��$ darkgray��$ 	lightgray���� -
   $��
Export_btn��$��3��$��1��$��90��$��20��$��Export��$
 True��$ darkgray��$ 	lightgray��