   M S B A M L   `   `   `  ���� L  HCatLitterMoneyBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CatLitterMoneyBoxCatLitterMoneyBox  "    CatLitterMoneyBox.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:CatLitterMoneyBox     -     �Name$  Main_Window�� � Title$ 
MainWindow��4  .System.Windows.Automation.AutomationProperties   HelpText$ 	Katzenklo��$	��670��$	��625��.��� .+��  J� RenderTransformOrigin$ 0.512,0.465&�z�V� .~��� �� ��  �� Angle$ 0.102Q�T� .+��� -    ��Name$ 
Kloeins_cb��$��Ein Klo��$��Bahnschrift Light)�$��14(�$ 0.833,-0.749&�$
��Left=�$	��Top=�$��360,145,0,0q��� -   $ 
Klozwei_cb��$��
Beide Klos��$��Bahnschrift Light)�$��14(�$ 0.742,0.495&�$
��Left=�$	��Top=�$��360,175,0,0q��� $��	29,14,0,0q�$
��Wrap=�$��KatzenKlo Sparschwein��$	��Top=�$(��"Bahnschrift SemiBold SemiCondensed)�$��24(�$��23��$	��226��$ 0.5,0.5&�$
��Left=�z�V� .~��� �� �� $ 0.313Q�T�  T� X$ 0.146Q� T� Y$ 0.002Q�&   System.Windows.Controls.Calendar  -     Name$ Calendar_cal��$��	45,88,0,0q�$
��Left=�$	��Top=��� -   	 ��Name$	 werwars_tbl��$
��Wrap=�$��Wer hat geschuftet?��$��Bahnschrift Condensed)�$��18(�$
��Left=�$	��Top=�$��
360,47,0,0q��� -   $	 wannImCal_tbl��$
��Wrap=�$��Wann wurde geschafft?��$(��"Bahnschrift SemiBold SemiCondensed)�$��16(�$ 0.5,0.5&�$	��Top=�$
��Left=�$��	57,48,0,0q�z�V� .~��� �� �� $ 0.313Q�T� $ -0.207Q�$ -0.063Q��� -   
 ��Name$
 JobEintragen_btn��$��Job eintragen��$
��Left=�$	��Top=�$��360,242,0,0q��� -   $
 GuthabenAbfragen_btn��$��Guthaben Abfragen��$
��Left=�$	��Top=�$��
45,303,0,0q��� -	   $
 GuthabenAbheben_btn��$��Guthaben Abheben��$	��Top=�$
��Left=�$��
45,347,0,0q��� -
    ��Name$ Abhebebox_tbx�� �� TextWrapping$
 Wrap=�$
��0.00��${�False��$
��Left=�$	��Top=�$��180,303,0,0q�$��18��$��51���� -   $
 GuthabenAusbuchen_btn��$��Abheben!��$ 
0.25,0.319&�$
{�True��$	��Top=�$
��Left=�$��180,347,0,0q��� -   $
 UserAnlegen_btn��$��User anlegen��$��361,312,0,0q�$
��Left=�$	��Top=��� -   $
 UserLöschen_btn��$��User löschen��$��488,315,0,0q�$
��Left=�$	��Top=�z�V� .~��� �� �� T� �� -    ��Name$ User_drpdwn�� �� DisplayMemberPath$
 Name��$	��Top=�$
��Left=�$	��127��$��
360,91,0,0q� �� SelectedItem �� *SelectedAccount+�� -   $ BonusLottery_cb��$��Bonus Lotterie��$��Bahnschrift Light)�$��14(�$ 0.742,0.495&�$	��Top=�$
��Left=�$��360,204,0,0q��� -   $
 SonderEinzahlung_btn��$��Sonderzahlung��$ 
0.25,0.319&�$
{�True��$
��Left=�$	��Top=�$��
45,388,0,0q��� -   $
 LohnAnpassen_btn��$��Lohn anpassen��$ 
0.25,0.319&�$
{�True��$
��Left=�$	��Top=�$��
45,427,0,0q��� -   $
 ValueChange_btn��$��Ändern!��$
��Left=�$��180,429,0,0q�$	��Top=��� -   $ ValueChange_tbx��$
��Left=�$��180,399,0,0q�$
 Wrap=�$
��0,00��$	��Top=�$��54���� -    ��Name$ UserCreationName_lbl��$��	Username:��$
��Left=�$��363,369,0,0q�$	��Top=�$ 0.548,1.344&��� -   $ UserCreationName_tbx��$
��Left=�$��448,374,0,0q�$
 Wrap=�$	��Top=�$	��120���� -   $
 UserManipulation_btn��$
��Left=�$��407,403,0,0q�$	��Top=�$��27��$	��114��$��Eintrag speichern���� -   $ UserVorgang_lbl��$��Label��$
��Left=�$��440,344,0,0q�$	��Top=�