using System;
using System.ComponentModel;

namespace CatLitterMoneyBox.Model;
public class DataItem:INotifyPropertyChanged
    {
    public event PropertyChangedEventHandler PropertyChanged;

    #region Properties

    private DateTime _date { get; set; }
    public DateTime Date
        {
        get { return _date; }
        set
            {
            _date = value;
            OnPropertyChanged(nameof(Date));
            }
        }
    private string _name { get; set; }
    public string Name
        {
        get { return _name; }
        set
            {
            _name = value;
            OnPropertyChanged(nameof(Name));
            }
        }
    private double _salary { get; set; }
    public double Salary
        {
        get { return _salary; }
        set
            {
            _salary = value;
            OnPropertyChanged(nameof(Salary));
            }
        }

    private double _amountEarned { get; set; }
    public double AmountEarned
        {
        get { return _amountEarned; }
        set
            {
            _amountEarned = value;
            OnPropertyChanged(nameof(AmountEarned));
            }
        }

    private double _lotteryEarned { get; set; }
    public double LotteryEarned
        {
        get { return _lotteryEarned; }
        set
            {
            _lotteryEarned = value;
            OnPropertyChanged(nameof(LotteryEarned));
            }
        }

    private double _payOut { get; set; }
    public double PayOut
        {
        get { return _payOut; }
        set
            {
            _payOut = value;
            OnPropertyChanged(nameof(PayOut));
            }
        }

    private double _deposit { get; set; }
    public double Deposit
        {
        get { return _deposit; }
        set
            {
            _deposit = value;
            OnPropertyChanged(nameof(Deposit));
            }
        }

    #endregion

    public DataItem()
        {
        }

    public DataItem(DateTime date,string name,double salary,double amountEarned,double lotteryEarned,double deposit,double payOut)
        {
        Date = date;
        Name = name;
        Salary = salary;
        AmountEarned = amountEarned;
        LotteryEarned = lotteryEarned;
        Deposit = deposit;
        PayOut = payOut;
        }


    private void OnPropertyChanged(string propertyName)
        {
        PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
