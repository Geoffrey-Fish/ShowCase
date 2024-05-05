using System;
using System.ComponentModel;

namespace CatLitterMoneyBox.Model;

public class DataItem : INotifyPropertyChanged {
    public DataItem() { }

    public DataItem(
        DateTime date, string name, double salary, double amountEarned, double lotteryEarned, double deposit
        , double payOut) {
        Date          = date;
        Name          = name;
        Salary        = salary;
        AmountEarned  = amountEarned;
        LotteryEarned = lotteryEarned;
        Deposit       = deposit;
        PayOut        = payOut;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

#region Properties
    private DateTime _date { get; set; }

    public DateTime Date {
        get => _date;
        set {
            _date = value;
            OnPropertyChanged(nameof(Date));
        }
    }

    private string _name { get; set; }

    public string Name {
        get => _name;
        set {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    private double _salary { get; set; }

    public double Salary {
        get => _salary;
        set {
            _salary = value;
            OnPropertyChanged(nameof(Salary));
        }
    }

    private double _amountEarned { get; set; }

    public double AmountEarned {
        get => _amountEarned;
        set {
            _amountEarned = value;
            OnPropertyChanged(nameof(AmountEarned));
        }
    }

    private double _lotteryEarned { get; set; }

    public double LotteryEarned {
        get => _lotteryEarned;
        set {
            _lotteryEarned = value;
            OnPropertyChanged(nameof(LotteryEarned));
        }
    }

    private double _payOut { get; set; }

    public double PayOut {
        get => _payOut;
        set {
            _payOut = value;
            OnPropertyChanged(nameof(PayOut));
        }
    }

    private double _deposit { get; set; }

    public double Deposit {
        get => _deposit;
        set {
            _deposit = value;
            OnPropertyChanged(nameof(Deposit));
        }
    }
#endregion
}