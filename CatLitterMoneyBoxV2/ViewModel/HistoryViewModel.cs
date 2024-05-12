using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

using CatLitterMoneyBox.Model;

namespace CatLitterMoneyBox.ViewModel;

public class HistoryViewModel : INotifyPropertyChanged {
#region Properties
    public event PropertyChangedEventHandler PropertyChanged;

    public enum Names {
        Felicitas
        , Paulinus
        , Jeff
        , Miri
    }

    //Main Datalist for manipulating and querries
    private ObservableCollection<DataItem> _allDataItems { get; set; }
    private ObservableCollection<DataItem> _currentData  { get; set; }
    private List<DataItem>                 _allUsers     { get; set; }
    private Names                          _selectedUser { get; set; }

    public ObservableCollection<DataItem> AllDataItems {
        get => _allDataItems;
        set {
            _allDataItems = value;
            OnPropertyChanged(nameof(AllDataItems));
        }
    }
    //Filtered Datalists get copied into this one here
    public ObservableCollection<DataItem> CurrentData {
        get => _currentData;
        set {
            _currentData = value;
            OnPropertyChanged(nameof(CurrentData));
        }
    }
    public List<DataItem> AllUsers {
        get => _allUsers;
        set {
            _allUsers = value;
            OnPropertyChanged(nameof(AllUsers));
        }
    }
    //Selected user from AccountDropdownList
    public Names SelectedUser {
        get => _selectedUser;
        set {
            _selectedUser = value;
            OnPropertyChanged(nameof(SelectedUser));
        }
    }
    public static string date     = DateTime.Now.ToShortDateString();
    public static string safeDate = date.Replace('/', '-');
#endregion

public HistoryViewModel() {
        AllDataItems = new ObservableCollection<DataItem>();
        LoadData();
        CurrentData = AllDataItems;
    }

    private void LoadData() {
        var connectionString = "Data Source=HistoryDataBase.sqlite;Version=3;";
        using(var connection = new SQLiteConnection(connectionString)) {
            connection.Open();
            var query = @"SELECT 
                        Date
                        ,Name
                        ,Salary
                        ,AmountEarned
                        ,LotteryEarned
                        ,Deposit
                        ,Withdraw
                        FROM HistoryDataTable";
            using(var command = new SQLiteCommand(query, connection)) {
                using(var reader = command.ExecuteReader()) {
                    while(reader.Read()) {
                        var dataItem = new DataItem {
                            Date = reader.GetDateTime(0)
                            ,Name = reader.GetString(1)
                            ,Salary = reader.GetDouble(2)
                            ,AmountEarned = reader.GetDouble(3)
                            ,LotteryEarned = reader.GetDouble(4)
                            ,Deposit = reader.GetDouble(5)
                            ,Withdraw = reader.GetDouble(6)
                        };
                        AllDataItems.Add(dataItem);
                    }
                }
            }
            connection.Close();
        }
    }

    /// <summary>
    ///     Simply selects one user and displays all information
    /// </summary>
    public void FilterOneUserOverView(string name) {
        var oneUser = AllDataItems.Where(x => x.Name == name).ToList();
        CurrentData = new ObservableCollection<DataItem>(oneUser);
    }

    /// <summary>
    ///     Filter by won lotteries
    /// </summary>
    public void FilterUserLottery(string name) {
        var lotteryUser = AllDataItems.Where(x => x.Name == name && x.LotteryEarned != 0).ToList();
        CurrentData = new ObservableCollection<DataItem>(lotteryUser);
    }

    /// <summary>
    ///     filter by payouts
    /// </summary>
    public void FilterUserPayOuts(string name) {
        var payOutUser = AllDataItems.Where(x => x.Name == name && x.Withdraw != 0).ToList();
        CurrentData = new ObservableCollection<DataItem>(payOutUser);
    }

    /// <summary>
    ///     filter the current money master
    /// </summary>
    public void FilterUserRich() {
        var richUser =
            AllDataItems.GroupBy(x => x.Name).Select(x => new DataItem {
                Name = x.Key, AmountEarned = x.Sum(y => y.AmountEarned)
            }).OrderByDescending(x => x.AmountEarned).ToList();
        CurrentData = new ObservableCollection<DataItem>(richUser);
    }

    /// <summary>
    ///     filter by deposits
    /// </summary>
    /// <param name="name"></param>
    public void FilterUserDeposits(string name) {
        var userDeposits = AllDataItems.Where(x => x.Name == name && x.Deposit > 0).ToList();
        CurrentData = new ObservableCollection<DataItem>(userDeposits);
    }

    /// <summary>
    ///     Reset all data to default
    /// </summary>
    public void ResetAllData() {
        LoadData();
        CurrentData = AllDataItems;
    }

    /// <summary>
    ///     Export to CSV file
    /// </summary>
    public void ExportToCSV() {
        string filePath = @$"./HistoryData{safeDate}.csv";
        var    csv      = new StringBuilder();
        csv.AppendLine("Date,Name,Salary,AmountEarned,LotteryEarned,Deposit,Withdraw"); // Header

        foreach(var item in AllDataItems) {
            csv.AppendLine($"{item.Date};{item.Name}{item.Salary};{item.AmountEarned};{item.LotteryEarned};{item.Deposit};{item.Withdraw}");
        }

        File.WriteAllText(filePath, csv.ToString());
        MessageBox.Show("File saved in Programfolder.");
    }

private void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}