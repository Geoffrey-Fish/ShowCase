using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;

using CatLitterMoneyBox.Model;

namespace CatLitterMoneyBox.ViewModel;


public class HistoryViewModel:INotifyPropertyChanged
    {

    #region Properties
    public event PropertyChangedEventHandler PropertyChanged;

    //Main Datalist for manipulating and querries
    private ObservableCollection<DataItem> _allDataItems { get; set; }
    public ObservableCollection<DataItem> AllDataItems
        {
        get { return _allDataItems; }
        set
            {
            _allDataItems = value;
            OnPropertyChanged(nameof(AllDataItems));
            }
        }
    //Filtered Datalists get copied into this one here
    private ObservableCollection<DataItem> _currentData { get; set; }
    public ObservableCollection<DataItem> CurrentData
        {
        get { return _currentData; }
        set
            {
            _currentData = value;
            OnPropertyChanged(nameof(CurrentData));
            }
        }

    private List<DataItem> _allUsers { get; set; }

    public List<DataItem> AllUsers
        {
        get { return _allUsers; }
        set
            {
            _allUsers = value;
            OnPropertyChanged(nameof(AllUsers));
            }

        }

    //Selected user from AccountDropdownList
    private DataItem _selectedUser { get; set; }

    public DataItem SelectedUser
        {
        get { return _selectedUser; }
        set
            {
            _selectedUser = value;
            OnPropertyChanged(nameof(SelectedUser));
            }
        }
    //hk, i have deep right now, so sorry

    #endregion

    /// <summary>
    /// Initialize the window, load all data from Database, display it in Datagrid(CurrentData)
    /// </summary>
    public HistoryViewModel()
        {
        AllDataItems = new ObservableCollection<DataItem>();
        LoadData();
        CurrentData = AllDataItems;
        }



    private void LoadData()
        {
        string connectionString = "Data Source=HistoryDataBase.sqlite;Version=3;";
        using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
            connection.Open();

            string query = "SELECT Date, Name, Salary, AmountEarned, LotteryEarned FROM HistoryDataTable";
            using(SQLiteCommand command = new SQLiteCommand(query,connection))
                {
                using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                    while(reader.Read())
                        {
                        var dataItem = new DataItem
                            {
                            Date = reader.GetDateTime(0),
                            Name = reader.GetString(1),
                            Salary = reader.GetDouble(2),
                            AmountEarned = reader.GetDouble(3),
                            LotteryEarned = reader.GetDouble(4)
                            };
                        AllDataItems.Add(dataItem);
                        }
                    }
                }

            connection.Close();
            }
        }
    /// <summary>
    /// Simply selects one user and displays all information
    /// </summary>
    /// <param name="name"></param>
    public void FilterUserOverView(string name)
        {
        List<DataItem> oneUser = AllDataItems.Where(x => x.Name == name).ToList();
        CurrentData = new ObservableCollection<DataItem>(oneUser);
        }

    /// <summary>
    /// Filter by won lotteries
    /// </summary>
    /// <param name="name"></param>
    public void FilterUserLottery(string name)
        {
        List<DataItem> lotteryUser = AllDataItems.Where(x => x.Name == name && x.LotteryEarned != 0).ToList();
        CurrentData = new ObservableCollection<DataItem>(lotteryUser);
        }

    /// <summary>
    /// filter by payouts
    /// </summary>
    /// <param name="name"></param>
    public virtual void FilterUserPayOuts(string name)
        {
        List<DataItem> payOutUser = AllDataItems.Where(x => x.Name == name && x.PayOut != 0).ToList();
        CurrentData = new ObservableCollection<DataItem>(payOutUser);
        }

    /// <summary>
    /// filter the current money master
    /// </summary>
    /// <param name="name"></param>
    public void FilterUserRich()
        {
        List<DataItem> richUser =
        AllDataItems.GroupBy(x => x.Name).Select(x => new DataItem
            {
            Name = x.Key,
            AmountEarned = x.Sum(y => y.AmountEarned)
            }).OrderByDescending(x => x.AmountEarned).ToList();
        CurrentData = new ObservableCollection<DataItem>(richUser);
        }

    public void FilterUserDeposits(string name)
        {
        List<DataItem> userDeposits = AllDataItems.Where(x => x.Name == name && x.Deposit > 0).ToList();
        CurrentData = new ObservableCollection<DataItem>(userDeposits);
        }

    private void OnPropertyChanged(string propertyName)
        {
        PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }

    }
