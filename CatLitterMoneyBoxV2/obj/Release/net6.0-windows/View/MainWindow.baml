   M S B A M L   `   `   `  ���� L  HCatLitterMoneyBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CatLitterMoneyBoxCatLitterMoneyBox  G(clr-namespace:CatLitterMoneyBox.CommandsCatLitterMoneyBox.Commands  G(clr-namespace:CatLitterMoneyBox.ControlsCatLitterMoneyBox.Controls  "    CatLitterMoneyBox.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:CatLitterMoneyBox     =commands(clr-namespace:CatLitterMoneyBox.Commands     =controls(clr-namespace:CatLitterMoneyBox.Controls     -     �Name$  Main_Window��
������� � Title$ Katzenklo V2��4  .System.Windows.Automation.AutomationProperties   HelpText$ 	Katzenklo��$	��670��$	��625�� � 	Resources 6   0CatLitterMoneyBox.Commands.ColorToBrushConverter   ColorToBrushConverter �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%4  &	        '��        �� " ��.���  � ��
 �������  � ��
 ��  ���  � ��$ 12(���  � ��$
 Bold"���  � ��$
 10,5q���  � ��$ 80����  � ��$	 120����  � ��$ 30����  � �� �� " ��.R��� $ 10��#��z��._��� $��Center=�$��Center=�.���� 
�����_�$��5q�$ 10��$��5q�._�� -   $��MainGrid��	 � ColumnDefinitions	 �� $��* ��� $��* �
 � RowDefinitions
 �� $��* ��� $��* �.+��� $��0��$��0��
����+��$��5q�$ 20��$��5q�._�� -   $��Upleft��$��0��$��0��$��5q�
 �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��KatzenKlo Sparschwein��$(��"Bahnschrift SemiBold SemiCondensed)�$��24(�$��Center=��� -    ��Name$ wannImCal_tbl��$��1��$��Wann wurde geschafft?��$(��"Bahnschrift SemiBold SemiCondensed)�$��16(�$	��Top=�$��Center=�$��0,5,0,0q�&   System.Windows.Controls.Calendar  -     Name$ Calendar_cal��$��2��$��0,20,0,0q�   SelectedDate �� *Calendarcal+�� $��0��$��1��
����+��$��5q�$ 20��$��5q�._�� -   $��Upright��$��5q�	 �� $��* ��� $��* �
 �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* �.+��� -   $��werwars_tbl��$��0��$��2��$��Wer hat geschuftet?��$��Bahnschrift Condensed)�$��18(�$��Center=�$��Center=��� -   $��User_drpdwn��$��1��$��2��$	��100��$��25�� �� DisplayMemberPath$
 Name������ *BankAccounts+ �� SelectedItem �� *SelectedAccount+	� -	   $��
Kloeins_cb��$��2��$��Ein Klo��$��Bahnschrift Light)�$��14(�$��Center=�$��Center=� d� 	IsChecked �� *
CheckOne+	� -
   $��
Klozwei_cb��$��2��$��1��$��
Beide Klos��$��Bahnschrift Light)�$��14(�$��Center=�$��Center=� �� *
CheckTwo+�� -   $��BonusLottery_cb��$��3��$��2��$��Center=�$��Bonus Lotterie��$��Bahnschrift Light)�$��14(��� -   $��JobEintragen_btn��$��4��$��2��$��Job eintragen��$	��Top=�5   /CatLitterMoneyBox.Controls.ColorChangingOnClick$   IsColorChangingOnClickEnabled$
 True��   TemporaryColor$ darkgray��   OriginalColor$ 	lightgray���� $��1��$��0��
����+��$��5q�$ 20��$��5q�._�� -   $��Downleft��$��5q�	 �� $��* ��� $��* �
 �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� -   $��GuthabenAbfragen_btn��$��Guthaben Abfragen��$
 True��$ darkgray��$ 	lightgray���� -   $��GuthabenAbheben_btn��$��0��$��1��$��Guthaben Abheben��$
 True��$ darkgray��$ 	lightgray���� -   $��Abhebebox_tbx��$��1��$��0��$��80��$��30������ *AbhebeboxtbxCol+ �� 	Converter# [  ���� *AbhebeboxtbxTxt+|��� *AbhebeboxtbxFoc+�� -   $��GuthabenAusbuchen_btn��$��1��$��1��$��Abheben!��$
 True��$ darkgray��$ 	lightgray��{��� *GuthabenAusbuchenbtnEna+�� -   $��LohnAnpassen_btn��$��2��$��Lohn anpassen��$
 True��$ darkgray��$ 	lightgray���� -   $��SonderEinzahlung_btn��$��2��$��1��$��Sonderzahlung��$
 True��$ darkgray��$ 	lightgray���� -   $��ValueChange_tbx��$��3��$��0��$��80��$��30������ *ValueChangetbxCol+# [  ���� *ValueChangetbxTxt+|��� *ValueChangetbxFoc+�� -   $��ValueChange_btn��$��3��$��1��$��Ändern!��$
 True��$ darkgray��$ 	lightgray��{��� *ValueChangebtnEna+�� -   $��	Reset_btn��$��4��$��0��$��Reset��$
 True��$ darkgray��$ 	lightgray���� -   $��Test_btn��$��4��$��1��$��Debug��$
 True��$ darkgray��$ 	lightgray���� $��1��$��1��
����+��$��5q�$ 20��$��5q�._�� -   $��	Downright��$��5q�	 �� $��* ��� $��* �
 �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� -   $��UserAnlegen_btn��$��User anlegen��$
 True��$ darkgray��$ 	lightgray���� -   $��UserLöschen_btn��$��1��$��User löschen��$
 True��$ darkgray��$ 	lightgray���� -   $��UserVorgang_lbl��$��1��$��2��$	��200��$��30������ *UserVorganglblTxt+� $��2��$��2��.+��� -   $��UserCreationName_lbl��$	��120��$��30��$��	Username:���� -   $��UserCreationName_tbx��$	��100��$��30������ *UserCreationNametbxCol+# [  ���� *UserCreationNametbxTxt+|��� *UserCreationNametbxFoc+�� -   $��UserManipulation_btn��$��3��$��2��$��Eintrag speichern��$
 True��$ darkgray��$ 	lightgray���� -   $��HistoryWindow_btn��$��4��$��2��$��Historie��$
 True��$ darkgray��$ 	lightgray��