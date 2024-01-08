using System.Windows;

using CatLitterMoneyBox.Model;
using CatLitterMoneyBox.ViewModel;

namespace CatLitterMoneyBox.View;
/// <summary>
/// Interaction logic for HistoryView.xaml
/// </summary>
public partial class HistoryView:Window
    {
    private HistoryViewModel viewModel; //Always put this in here
    public HistoryView()
        {
        InitializeComponent();
        viewModel = new HistoryViewModel(); //because here you start it
        DataContext = viewModel; //after which you can assign it as dadacontext
        }
    #region ButtonClicks
    private void Verdienst_btn_OnClick(object sender,RoutedEventArgs e) //And now you can use it here
        {
        if(AccountList_drpdwn.SelectionBoxItem != null)
            {
            DataItem user = (DataItem)AccountList_drpdwn.SelectionBoxItem;
            viewModel.FilterUserOverView(user.Name);
            }
        else
            {
            MessageBox.Show("Bitte Person auswählen.");
            }

        }

    private void Lottery_btn_OnClick(object sender,RoutedEventArgs e)
        {
        if(AccountList_drpdwn.SelectionBoxItem != null)
            {
            DataItem user = (DataItem)AccountList_drpdwn.SelectionBoxItem;
            viewModel.FilterUserLottery(user.Name);
            }
        else
            {
            MessageBox.Show("Bitte Person auswählen.");
            }
        }

    private void Payout_btn_OnClick(object sender,RoutedEventArgs e)
        {
        if(AccountList_drpdwn.SelectionBoxItem != null)
            {
            DataItem user = (DataItem)AccountList_drpdwn.SelectionBoxItem;
            viewModel.FilterUserPayOuts(user.Name);
            }
        else
            {
            MessageBox.Show("Bitte Person auswählen.");
            }
        }

    private void Richest_btn_OnClick(object sender,RoutedEventArgs e)
        {
        viewModel.FilterUserRich();
        }


    #endregion

    }
