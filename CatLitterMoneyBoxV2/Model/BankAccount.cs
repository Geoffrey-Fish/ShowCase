using System;

namespace CatLitterMoneyBox.Model;

public class BankAccount {
    public BankAccount(string name, DateTime date, double salary, double money) {
        Name   = name;
        Date   = date;
        Salary = salary;
        Money  = money;
    }

    public string   Name   { get; set; } //who
    public DateTime Date   { get; set; } //last job
    public double   Salary { get; set; } //how much they earn per toilet
    public double   Money  { get; set; } //Balance
}