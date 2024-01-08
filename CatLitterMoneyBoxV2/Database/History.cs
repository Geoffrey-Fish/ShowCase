using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows;

using CatLitterMoneyBox.Model;

namespace CatLitterMoneyBox.Database;

public class History
    {
    private static readonly string connectionString = "Data Source=HistoryDataBase.sqlite;Version=3;";

    /// <summary>
    ///     Template for all operations regarding saving datafiles
    /// And will be used at system start
    /// </summary>
    public static void ConnectHistory()
        {
        using(var connection = new SQLiteConnection(connectionString))
            {
            connection.Open();
            using(var command =
                   new SQLiteCommand(
                       "CREATE TABLE IF NOT EXISTS HistoryDataTable (Id INTEGER PRIMARY KEY, Date DATETIME, Name TEXT, Salary DOUBLE, AmountEarned DOUBLE, LotteryEarned DOUBLE)",
                       connection))
                {
                command.ExecuteNonQuery();
                }
            //
            //
            //
            //Do your mojo

            connection.Close();
            }
        }

    /// <summary>
    ///     Data items is the info send by the main logic.
    ///     earned, withdrawn, lotterie, etc.
    /// </summary>
    public static bool SaveMainData(List<DataItem> DataItems)
        {
        using(var connection = new SQLiteConnection(connectionString))
            {
            connection.Open();
            using(var transaction = connection.BeginTransaction())
                {
                try
                    {
                    var query =
                        "INSERT INTO HistoryDataTable (Date, Name, Salary, AmountEarned, LotteryEarned) VALUES (@Date,@Name,@Salary,@AmountEarned, @LotteryEarned)";
                    foreach(var item in DataItems)
                        using(var command = new SQLiteCommand(query,connection))
                            {
                            command.Parameters.AddWithValue("@Date",item.Date);
                            command.Parameters.AddWithValue("@Name",item.Name);
                            command.Parameters.AddWithValue("@Salary",item.Salary);
                            command.Parameters.AddWithValue("@AmountEarned",item.AmountEarned);
                            command.Parameters.AddWithValue("@LotteryEarned",item.LotteryEarned);

                            command.ExecuteNonQuery();
                            }

                    transaction.Commit();
                    }
                catch(Exception ex)
                    {
                    transaction.Rollback();
                    MessageBox.Show("Hard error, database did not save correctly!");
                    }

                connection.Close();
                }

            //
            return false;
            }
        //todo: historyview dropdown lists every enty user instead of just one time. need change
        // when was no litter done?
        // idea: this is an interesting search algo i think -
        // be it with a day counter from the last date? is there a method for it already?
        // Who worked the most times
        // one date when logged, the other when was the job done
        // one way to count the amount of jobs and the amount of boxes done
        // history about when the salary was changed
        // history of withdrawals and deposits

        }
    }