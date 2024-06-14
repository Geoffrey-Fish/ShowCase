using System;
using System.Windows.Input;

namespace SaarlandCalcV01.Commands
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;

        public RelayCommand(Action<T> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (parameter is T validParameter)
            {
                _execute(validParameter);
            }
        }
    }
}