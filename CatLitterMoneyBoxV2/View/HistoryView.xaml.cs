using System.Windows;

using CatLitterMoneyBox.ViewModel;

namespace CatLitterMoneyBox.View;

public partial class HistoryView : Window {
    private HistoryViewModel viewModel;

    public HistoryView() {
        InitializeComponent();
        viewModel   = new HistoryViewModel();
        DataContext = viewModel;
    }

    private void Verdienst_btn_OnClick(object sender, RoutedEventArgs e) {
        if(AccountList_drpdwn.SelectionBoxItem != null) {
            var user = AccountList_drpdwn.SelectionBoxItem.ToString();
            viewModel.FilterOneUserOverView(user);
        } else { MessageBox.Show("Bitte Person auswählen."); }
    }

    private void Lottery_btn_OnClick(object sender, RoutedEventArgs e) {
        if(AccountList_drpdwn.SelectionBoxItem != null) {
            var user = AccountList_drpdwn.SelectionBoxItem.ToString();
            viewModel.FilterUserLottery(user);
        } else { MessageBox.Show("Bitte Person auswählen."); }
    }

    private void Payout_btn_OnClick(object sender, RoutedEventArgs e) {
        if(AccountList_drpdwn.SelectionBoxItem != null) {
            var user = AccountList_drpdwn.SelectionBoxItem.ToString();
            viewModel.FilterUserPayOuts(user);
        } else { MessageBox.Show("Bitte Person auswählen."); }
    }

    private void Richest_btn_OnClick(object sender, RoutedEventArgs e) { viewModel.FilterUserRich(); }

    private void Reset_btn_Click(object sender, RoutedEventArgs e) {
        AccountList_drpdwn = null;
        viewModel.ResetAllData(); }

    private void Export_btn_Click(object sender,RoutedEventArgs e)
        {
        viewModel.ExportToCSV();
        }
    }