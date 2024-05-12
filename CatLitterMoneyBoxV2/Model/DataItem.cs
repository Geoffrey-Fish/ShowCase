using System;
using System.ComponentModel;

namespace CatLitterMoneyBox.Model;

public class DataItem : INotifyPropertyChanged {
    public DataItem() { }

    public DataItem(
        DateTime date, string name, double salary, double amountEarned, double lotteryEarned, double deposit
        , double withdraw) {
        Date          = date;
        Name          = name;
        Salary        = salary;
        AmountEarned  = amountEarned;
        LotteryEarned = lotteryEarned;
        Deposit       = deposit;
        Withdraw      = withdraw;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

#region Properties
    private DateTime _date          { get; set; }
    private string   _name          { get; set; }
    private double   _salary        { get; set; }
    private double   _amountEarned  { get; set; }
    private double   _lotteryEarned { get; set; }
    private double   _deposit       { get; set; }
    private double   _withdraw      { get; set; }
    public DateTime Date {
        get => _date;
        set {
            _date = value;
            OnPropertyChanged(nameof(Date));
        }
    }
    public string Name {
        get => _name;
        set {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    public double Salary {
        get => _salary;
        set {
            _salary = value;
            OnPropertyChanged(nameof(Salary));
        }
    }
    public double AmountEarned {
        get => _amountEarned;
        set {
            _amountEarned = value;
            OnPropertyChanged(nameof(AmountEarned));
        }
    }
    public double LotteryEarned {
        get => _lotteryEarned;
        set {
            _lotteryEarned = value;
            OnPropertyChanged(nameof(LotteryEarned));
        }
    }
    public double Deposit {
        get => _deposit;
        set {
            _deposit = value;
            OnPropertyChanged(nameof(Deposit));
        }
    }
    public double Withdraw {
        get => _withdraw;
        set {
            _withdraw = value;
            OnPropertyChanged(nameof(Withdraw));
        }
    }
#endregion
}