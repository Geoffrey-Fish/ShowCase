using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using CatLitterMoneyBox.View;
using CatLitterMoneyBox.ViewModel;

namespace CatLitterMoneyBox;

public partial class MainWindow:Window
    {
    #region statics

    private MainViewModel mainView;

    #endregion statics

    #region Checkboxes & Radios

    private void Kloeins_rdo_Checked(object sender,RoutedEventArgs e)
        {
        mainView.CheckOne = true;
        mainView.CheckTwo = false;
        }

    private void Klozwei_rdo_Checked(object sender,RoutedEventArgs e)
        {
        mainView.CheckTwo = true;
        mainView.CheckOne = false;
        }

    private void BonusLottery_cb_Checked(object sender,RoutedEventArgs e)
        {
        mainView.CheckLottery = true;
        }

    #endregion Checkboxes & Radios


    #region Init Constructor

    public MainWindow()
        {
        InitializeComponent();
        mainView = new MainViewModel();
        this.DataContext = mainView; //This is a binder that says the mainwindow itself is source for all interface elements
        Closing += MainWindow_Closing;
        }

    #endregion

    #region Bankaccounts
    private void UserAnlegen_btn_Click(object sender,RoutedEventArgs e) //New User creation
        {
        mainView.UserAnlegen();
        }

    private void UserLöschen_btn_Click(object sender,RoutedEventArgs e) //Userdeletion
        {
        mainView.UserLöschen();
        }

    private void UserManipulation_btn_Click(object sender,RoutedEventArgs e) //process chosen order
        {
        mainView.UserManipulation();
        }

    #endregion BankAccounts

    #region Money special buttons

    //Change the amount given for the job done
    private void LohnAnpassen_btn_Click(object sender,RoutedEventArgs e)
        {
        mainView.LohnAnpassen();
        }

    //Adding Money
    private void SonderEinzahlung_btn_Click(object sender,RoutedEventArgs e)
        {
        mainView.SonderEinzahlung();
        }

    private void ValueChange_btn_Click(object sender,RoutedEventArgs e)
        {
        mainView.ValueChange();
        }

    #endregion Money special buttons

    #region Money manipulations


    private void JobBuchen_btn_Click(object sender,RoutedEventArgs e)
        {
        mainView.JobBuchen();
        }

    private void AbfrageGuthaben_btn_Click(object sender,RoutedEventArgs e)
        {
        mainView.AbfrageGuthaben();
        }

    #endregion Money manipulations

    #region Abbuchungsvorgang

    //Inputbox only active if button pressed.
    private void AbhebenGuthaben_btn_Click(object sender,RoutedEventArgs e)
        {
        mainView.AbhebenGuthaben();
        }


    private void Abheben_btn_Click(object sender,RoutedEventArgs e)
        {
        mainView.Abheben();
        }

    #endregion Abbuchungsvorgang


    #region Misc

    private void Calendar_cal_OnDisplayDateChanged(object? sender,CalendarDateChangedEventArgs e)
        {
        mainView.Calendarcal = Calendar_cal.SelectedDate.Value;
        MessageBox.Show($"today is {Calendar_cal.SelectedDate}");
        }

    /// <summary>
    /// Clear all values
    /// </summary>
    private void Reset_btn_OnClick(object sender,RoutedEventArgs e)
        {
        mainView.ClearAll();
        }

    private void MainWindow_Closing(object sender,CancelEventArgs e)
        {
        mainView.SafeBankAccounts();
        }

    #endregion

    #region HistoryWindow
    /// <summary>
    /// open Datalog window
    /// </summary>
    private void HistoryWindow_btn_OnClick(object sender,RoutedEventArgs e)
        {
        HistoryView historyView = new HistoryView();
        historyView.Show();
        //All further stuff must go to: HistoryViewModel
        }

    #endregion

    }