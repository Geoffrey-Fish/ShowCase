using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

using CatLitterMoneyBox.Database;
using CatLitterMoneyBox.Model;

using Newtonsoft.Json;

using Color = System.Drawing.Color;

namespace CatLitterMoneyBox.ViewModel;
public class MainViewModel:INotifyPropertyChanged
    {

    #region statics

    //Some static values so my code works per se
    public bool CheckOne; //Checkbox checked
    public bool CheckTwo; //Checkbox checked
    public bool CheckLottery; //Checkbox checked
    public bool UserCreation; // New user button pressed
    public bool UserDeletion; // User deletion button pressed
    public bool SonderZahlung; // Extra money,yeah
    public bool LohnAnpassung; //We want more!We want more!
    private List<BankAccount> _bankAccounts { get; set; }
    public List<BankAccount> BankAccounts
        {
        get { return _bankAccounts; }
        set { _bankAccounts = value; OnPropertyChanged(nameof(BankAccounts)); }
        } //gets initialized on startup

    private string path = ".\\BankAccounts.json"; //Path to database
    private BankAccount _selectedAccount { get; set; }
    public BankAccount SelectedAccount
        {
        get { return _selectedAccount; }
        set { _selectedAccount = value; OnPropertyChanged(nameof(SelectedAccount)); }
        }//getter from the dropdown menu

    #endregion statics

    #region labelstuff

    private string _userCreationNametbxTxt { get; set; }
    public string UserCreationNametbxTxt
        {
        get { return _userCreationNametbxTxt; }
        set
            {
            _userCreationNametbxTxt = value;
            OnPropertyChanged(nameof(_userCreationNametbxTxt));
            }
        }

    private Color _userCreationNametbxCol { get; set; }
    public Color UserCreationNametbxCol
        {
        get { return _userCreationNametbxCol; }
        set
            {
            _userCreationNametbxCol = value;
            OnPropertyChanged(nameof(UserCreationNametbxCol));
            }
        }

    private string? _userCreationNamelblTxt { get; set; }
    public string? UserCreationNamelblTxt
        {
        get { return _userCreationNamelblTxt; }
        set { _userCreationNamelblTxt = value; OnPropertyChanged(nameof(UserCreationNamelblTxt)); }
        }

    private string? _userVorganglblTxt { get; set; }
    public string? UserVorganglblTxt
        {
        get { return _userVorganglblTxt; }
        set { _userVorganglblTxt = value; OnPropertyChanged(nameof(UserVorganglblTxt)); }
        }

    private bool _valueChangetbxFoc { get; set; }
    public bool ValueChangetbxFoc
        {
        get { return _valueChangetbxFoc; }
        set { _valueChangetbxFoc = value; OnPropertyChanged(nameof(ValueChangetbxFoc)); }
        }

    private string? _valueChangetbxTxt { get; set; }
    public string? ValueChangetbxTxt
        {
        get { return _valueChangetbxTxt; }
        set { _valueChangetbxTxt = value; OnPropertyChanged(nameof(ValueChangetbxTxt)); }
        }

    private Color _valueChangetbxCol { get; set; }
    public Color ValueChangetbxCol
        {
        get { return _valueChangetbxCol; }
        set { _valueChangetbxCol = value; OnPropertyChanged(nameof(ValueChangetbxCol)); }
        }

    private DateTime _calendarcal;
    public DateTime Calendarcal
        {
        get { return _calendarcal; }
        set
            {
            _calendarcal = value;
            OnPropertyChanged(nameof(Calendarcal));
            }
        }

    private bool _abhebeboxtbxFoc;
    public bool AbhebeboxtbxFoc
        {
        get
            {
            return _abhebeboxtbxFoc;
            }
        set
            {
            _abhebeboxtbxFoc = value;
            OnPropertyChanged(nameof(AbhebeboxtbxFoc));
            }
        }

    private string? _abhebeboxtbxTxt;
    public string? AbhebeboxtbxTxt
        {
        get
            {
            return _abhebeboxtbxTxt;
            }
        set
            {
            _abhebeboxtbxTxt = value;
            OnPropertyChanged(nameof(AbhebeboxtbxTxt));
            }
        }

    private Color _abhebeboxtbxCol { get; set; }
    public Color AbhebeboxtbxCol
        {
        get { return _abhebeboxtbxCol; }
        set
            {
            _abhebeboxtbxCol = value;
            OnPropertyChanged(nameof(AbhebeboxtbxCol));
            }
        }

    private bool _guthabenAusbuchenbtnEna { get; set; }

    public bool GuthabenAusbuchenbtnEna
        {
        get { return _guthabenAusbuchenbtnEna; }
        set
            {
            _guthabenAusbuchenbtnEna = value;
            OnPropertyChanged(nameof(GuthabenAusbuchenbtnEna));
            }
        }

    private bool _valueChangebtnEna { get; set; }
    public bool ValueChangebtnEna
        {
        get { return _valueChangebtnEna; }
        set
            {
            _valueChangebtnEna = value;
            OnPropertyChanged(nameof(ValueChangebtnEna));
            }
        }

    private bool _userManipulationbtnEna { get; set; }
    public bool UserManipulationbtnEna
        {
        get { return _userManipulationbtnEna; }
        set
            {
            _userManipulationbtnEna = value;
            OnPropertyChanged(nameof(UserManipulationbtnEna));
            }
        }

    #endregion

    public MainViewModel()
        {
        InitializeBankAccounts();
        //statics inits
        CheckOne = false;
        CheckTwo = false;
        CheckLottery = false;
        UserCreation = false;
        UserDeletion = false;
        SonderZahlung = false;
        LohnAnpassung = false;
        //labelstuff inits
        UserCreationNametbxTxt = "";
        UserCreationNametbxCol = Color.DarkGray;
        UserCreationNamelblTxt = "";
        UserVorganglblTxt = "";
        ValueChangetbxFoc = false;
        ValueChangetbxTxt = "";
        ValueChangetbxCol = Color.DarkGray;
        AbhebeboxtbxFoc = false;
        AbhebeboxtbxTxt = "";
        AbhebeboxtbxCol = Color.DarkGray;
        GuthabenAusbuchenbtnEna = false;
        ValueChangebtnEna = false;
        UserManipulationbtnEna = false;

        //Start the Database in case of first time use
        History.ConnectHistory();
        }

    #region Bankaccounts

    private void InitializeBankAccounts() //Load and initialize the database list of Bankaccounts
        {
        if(File.Exists(path))
            {
            BankAccounts = JsonConvert.DeserializeObject<List<BankAccount>>(File.ReadAllText(path)); //nice nested readfunction genius
            }
        else
            {
            MessageBox.Show("Sorry, no file there.Made a new List instead.");
            BankAccounts = new List<BankAccount>();
            }
        }


    /// <summary>
    /// After button is pressed, these are the preparations for the account creation
    /// </summary>
    public void UserAnlegen() //New User creation
        {
        UserVorganglblTxt = "Erstellmodus";
        UserCreationNametbxCol = Color.LightCyan;
        //Set flags for submit button
        UserCreation = true;
        UserDeletion = false;
        UserManipulationbtnEna = true;
        }

    /// <summary>
    /// after button is pressed, these are the preparations to Delete an account
    /// </summary>
    public void UserLöschen() //Userdeletion
        {
        if(SelectedAccount != null)
            {
            if(SelectedAccount.Money > 0)
                {
                MessageBox.Show(
                    $"Stop! {SelectedAccount.Name} still has {SelectedAccount.Money.ToString("C")} balance! First pay out, then erase account.");
                }
            else
                {
                MessageBox.Show($"{SelectedAccount.Name} shall be deleted?");
                UserVorganglblTxt = "Löschvorgang";
                //Set flags for submit button
                UserDeletion = true;
                UserCreation = false;
                UserManipulationbtnEna = true;
                UserCreationNametbxTxt = SelectedAccount.Name;
                }
            }
        else
            {
            MessageBox.Show("Please choose a Name from the dropdown first.");
            }
        }
    /// <summary>
    /// Create or delete an account execution process
    /// </summary>
    public void UserManipulation()//process chosen order
        {
        if(UserCreation)
            {
            var userName = UserCreationNametbxTxt;
            BankAccounts.Add(new BankAccount(userName,DateTime.Today,0.10,0));
            }

        if(UserDeletion)
            {
            MessageBox.Show($"{SelectedAccount.Name} is deleted.");
            BankAccounts.Remove(SelectedAccount);
            SelectedAccount = null; //kind of cleanup 
            }

        //Clear to status quo
        UserVorganglblTxt = "";
        UserCreationNametbxTxt = "";
        UserManipulationbtnEna = false;
        UserCreation = false;
        UserDeletion = false;
        }

    #endregion BankAccounts

    #region Money special buttons

    /// <summary>
    /// Preparation for to change the amount of salary
    /// </summary>
    public void LohnAnpassen()
        {
        ValueChangetbxFoc = true;
        ValueChangetbxCol = Color.LightCyan;
        ValueChangetbxTxt = SelectedAccount.Salary.ToString(); //Current Salary display
        ValueChangebtnEna = true;
        //Flags for submit button
        LohnAnpassung = true;
        SonderZahlung = false;
        }

    /// <summary>
    /// Preparation for adding extra money to the selected account
    /// </summary>
    public void SonderEinzahlung()
        {
        ValueChangetbxFoc = true;
        ValueChangetbxCol = Color.LightCyan;
        ValueChangetbxTxt = "0,00";
        ValueChangebtnEna = true;
        //Flags for submit button
        SonderZahlung = true;
        LohnAnpassung = false;
        }


    /// <summary>
    /// This is for changing the Salary amount and for special payments on the account
    /// </summary>
    public void ValueChange()
        {
        double result = 0;
        if(LohnAnpassung)
            {
            double.TryParse(ValueChangetbxTxt,out result);
            SelectedAccount.Salary = result;
            MessageBox.Show($"{SelectedAccount.Name} now gets {SelectedAccount.Salary.ToString("##.##")} per Litterbox.");
            }

        if(SonderZahlung)
            {

            double.TryParse(ValueChangetbxTxt,out result);
            SelectedAccount.Money += result;
            MessageBox.Show($"{SelectedAccount.Name} got {result.ToString("##.##")} extra on the bank.");
            }
        //Either what was chosen,reset color
        ValueChangetbxCol = Color.DarkGray;
        ValueChangebtnEna = false;
        //set Flags back to negative
        LohnAnpassung = false;
        SonderZahlung = false;

        //I know it is not intelligent, but hay, it works at least. and it is save for future expansions
        //Save it in the Database
        DataItem dataItem = new(SelectedAccount.Date,SelectedAccount.Name,SelectedAccount.Salary,
            SelectedAccount.Money,0,result,0);

        List<DataItem> DataItems = new List<DataItem>();
        DataItems.Add(dataItem);
        History.SaveMainData(DataItems);

        }

    #endregion Money special buttons

    #region Money manipulations

    /// <summary>
    /// /Little fun lottery for extraordinary jobs done.Gets added to regular payment
    /// </summary>
    /// <returns>random sum</returns>
    private static double Lottery()
        {
        var wins = new[] { 0.5,0.10,0.5,0.15,0.10,0.20,0.15,0.30 };
        var rand = new Random();
        return wins[rand.Next(8)];
        }

    /// <summary>
    /// Adding money to the selected account balance for the akward job done
    /// </summary>
    public void JobBuchen()
        {
        if(SelectedAccount != null && (CheckOne || CheckTwo)) //Check if anything is chosen first
            {
            double lottery = 0;
            var salary = SelectedAccount.Salary;
            double i = 0;
            if(CheckOne)
                {
                i += salary;
                }
            else if(CheckTwo)
                {
                i += salary * 2;
                }

            if(CheckLottery) //Lucky you!
                {
                lottery = Lottery();
                MessageBox.Show($"{lottery.ToString("C")} Euro gewonnen!!");
                i += lottery; //Add lottery to sum
                }

            SelectedAccount.Money += i;
            SelectedAccount.Date = Calendarcal;
            MessageBox.Show($"Für {SelectedAccount.Name} wurden {i.ToString("C")} gebucht.");

            //Save it in the Database
            DataItem dataItem = new(SelectedAccount.Date,SelectedAccount.Name,SelectedAccount.Salary,
                SelectedAccount.Money,lottery,0,0);

            List<DataItem> DataItems = new List<DataItem>();
            DataItems.Add(dataItem);
            History.SaveMainData(DataItems);
            }
        else
            {
            MessageBox.Show("Bitte erst Account auswählen!");
            }
        }

    public void AbfrageGuthaben()
        {
        if(SelectedAccount != null)
            {
            MessageBox.Show(
                $"{SelectedAccount.Name} hat: {SelectedAccount.Money.ToString("0.00")} Euro.\n" +
                $"Lohn per Klo: {SelectedAccount.Salary.ToString("C")}\n" +
                $"Stand: {SelectedAccount.Date.ToShortDateString()}.");
            }
        else
            {
            MessageBox.Show("Bitte erst einen Account auswählen!");
            }
        }

    #endregion Money manipulations

    #region Abbuchungsvorgang

    /// <summary>
    /// Activate inputbox for withdrawal
    /// </summary>
    public void AbhebenGuthaben()
        {
        if(SelectedAccount != null)
            {
            AbhebeboxtbxFoc = true;
            AbhebeboxtbxCol = Color.LightCyan;
            AbhebeboxtbxTxt = "0,00";
            GuthabenAusbuchenbtnEna = true;
            }
        else
            {
            MessageBox.Show("Bitte erst einen Account auswählen!");
            }
        }

    /// <summary>
    /// Moneywithdrawal if sufficient balance on account
    /// </summary>
    public void Abheben()
        {
        var abhebung = double.Parse(AbhebeboxtbxTxt);
        if(abhebung > SelectedAccount.Money)
            {
            MessageBox.Show($"Soviel ist nicht vorhanden!\n" +
                            $"{SelectedAccount.Name} hat\n" +
                            $"{SelectedAccount.Money.ToString("0.00")} Euro\n" +
                            $"auf dem Konto.");
            AbhebeboxtbxTxt = SelectedAccount.Money.ToString("0.00");
            }
        else
            {
            SelectedAccount.Money -= abhebung;
            MessageBox.Show($"{abhebung.ToString("0.00")}" +
                            $" Euro erfolgreich abgebucht!\n" +
                            $"Es verbleiben {SelectedAccount.Money.ToString("0.00")} Euro\n" +
                            $" auf dem Konto von {SelectedAccount.Name}.");
            SelectedAccount.Date = Calendarcal;

            //Clean up
            AbhebeboxtbxFoc = false;
            AbhebeboxtbxCol = Color.DarkGray;
            GuthabenAusbuchenbtnEna = false;

            //Save it in the Database
            DataItem dataItem = new(SelectedAccount.Date,SelectedAccount.Name,SelectedAccount.Salary,
                SelectedAccount.Money,0,0,abhebung);

            List<DataItem> DataItems = new List<DataItem>();
            DataItems.Add(dataItem);
            History.SaveMainData(DataItems);
            }
        }

    #endregion Abbuchungsvorgang

    #region Testing / Clean off / Save before close
    /// <summary>
    /// Empty Testing Thingy
    /// </summary>
    public void Testing()
        {
        }

    /// <summary>
    /// A little bit clean up
    /// </summary>
    public void ClearAll()
        {
        UserCreationNamelblTxt = "";
        UserCreationNametbxTxt = "";
        UserCreationNametbxCol = Color.DarkGray;
        SelectedAccount = null;
        AbhebeboxtbxTxt = "";
        AbhebeboxtbxCol = Color.DarkGray;
        ValueChangetbxTxt = "";
        ValueChangetbxCol = Color.DarkGray;
        ValueChangebtnEna = false;
        GuthabenAusbuchenbtnEna = false;
        Calendarcal = DateTime.Today;
        CheckOne = false;
        CheckTwo = false;
        CheckLottery = false;

        }


    /// <summary>
    /// simple save, to be enlarged with database protocol
    /// </summary>
    public void SafeBankAccounts()
        {

        File.WriteAllText(path,JsonConvert.SerializeObject(BankAccounts));
        }

    /// <summary>
    /// gets called upon closing the app
    /// </summary>
    private void MainWindow_Closing(object sender,CancelEventArgs e)
        {
        // Perform your save operation here
        // SaveDataToCSV();
        SafeBankAccounts();
        }
    #endregion

    #region Propertychangedeventhandling

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
        PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }

    protected bool SetField<T>(ref T field,T value,[CallerMemberName] string? propertyName = null)
        {
        if(EqualityComparer<T>.Default.Equals(field,value))
            return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
        }
    #endregion


    }

