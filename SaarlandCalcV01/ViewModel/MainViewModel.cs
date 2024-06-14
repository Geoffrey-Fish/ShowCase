using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SaarlandCalcV01.Commands;
using SaarlandCalcV01.Model;
namespace SaarlandCalcV01.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region MainConstructor
        public MainViewModel()
        { 
            _converter = new Converter();
            NumberInputFinished = false;
            ButtonsActive = true;
        }

        #endregion

        #region Fields
        private ICommand _numberButtonCommand;
        private Converter _converter;
        private string[] _vonAuswahl = {"Saarland","Metrisch","Fussballfeld","Banane","Elefant","Kartoffel","Badewannen" };
        private string[] _nachAuswahl = {"Saarland","Metrisch","Fussballfeld","Banane","Elefant","Kartoffel","Badewannen" };
        private string _auswahlVon { get; set; }
        private string _auswahlNach { get; set; }
        private bool _numberInputFinished { get; set; }
        private bool _buttonsActive { get; set; }
        private string _displayText = "0";

        public ICommand NumberButtonCommand
        {
            get
            {
                return _numberButtonCommand ?? (_numberButtonCommand = new RelayCommand<string>(
                    ExecuteNumberButtonCommand));
            }
        }
        public string[] VonAuswahl => _vonAuswahl;
        public string[] NachAuswahl => _nachAuswahl;
        /// <summary>
        /// Convert the number from this
        /// </summary>
        public string AuswahlVon
        {
            get => _auswahlVon;
            set
            {
                _auswahlVon = value;
                OnPropertyChanged(nameof(AuswahlVon));
            }
        }
        /// <summary>
        /// Convert the number to this
        /// </summary>
        public string AuswahlNach
        {
            get => _auswahlNach;
            set
            {
                _auswahlNach = value;
                OnPropertyChanged(nameof(AuswahlNach));
            }
        }
        
        public string DisplayText
        {
            get => _displayText;
            set
            {
                if (_displayText != value)
                {
                    _displayText = value;
                    OnPropertyChanged(nameof(DisplayText));
                }
            }
        }

        /// <summary>
        /// When user presses Equals button, feel it!
        /// </summary>
        public bool NumberInputFinished
        {
            get => _numberInputFinished; 
        set
            {
                _numberInputFinished = value;
                OnPropertyChanged(nameof(NumberInputFinished));
            }
        }

        public bool ButtonsActive
        {
            get => _buttonsActive;
            set
            {
                _buttonsActive = value;
                OnPropertyChanged(nameof(ButtonsActive));
            }
        }

        #endregion
        private void ExecuteNumberButtonCommand(string buttonContent)
            {
                // Handle the number button click
                if (_displayText == "0" || _displayText == "Error")
                {
                    _displayText = buttonContent;
                }
                else if (buttonContent == "*" || buttonContent == "=" || buttonContent == "+" || buttonContent == "-" || buttonContent == "neu" || buttonContent == "LOS")
                {
                    switch (buttonContent)
                    {
                        case "neu":
                            ResetAll();
                            break;
                        case "*":
                            MessageBox.Show ( "Sorry, geht noch nicht!");
                            break;
                        case "+":
                            MessageBox.Show ( "Sorry, geht noch nicht!");
                            break;
                        case "-":
                            MessageBox.Show ( "Sorry, geht noch nicht!");
                            break;
                        case "LOS":
                            NumberInputFinished = true;
                            ButtonsActive = false;
                            _displayText = _converter.Convert(DisplayText, AuswahlVon, AuswahlNach);
                            break;
                        case "=": // Now, block further tinkering, send the collected data to the Converter.
                            NumberInputFinished = true;
                            ButtonsActive = false;
                            _displayText = _converter.Convert(DisplayText, AuswahlVon, AuswahlNach);
                            break;
                    }                
                }
                else
                {
                    _displayText += buttonContent;
                }
                //MessageBox.Show("shit is here");
                OnPropertyChanged(nameof(DisplayText));
            }

        private void ResetAll()
        {
            DisplayText = "0";
            ButtonsActive = true;
            NumberInputFinished = false;
            AuswahlVon = "Saarland";
            AuswahlNach = "Fussball";
        }

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}