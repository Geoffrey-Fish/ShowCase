using System;
using System.Windows.Input;


namespace ParkHouseV2.Commands;


public class RelayCommand:ICommand
	{
	public event EventHandler? CanExecuteChanged;

	private Action<object> _Execute { get; set; }
	private Predicate<object> _CanExecute { get; set; }

	public bool CanExecute(object? parameter)
		{
		return true;
		}

	public void Execute(object? parameter)
		{
		_Execute(parameter);
		}

	public RelayCommand(Action<object> execute,Predicate<object> canExecute)
		{
		_Execute = execute;
		_CanExecute = canExecute;
		}
	}