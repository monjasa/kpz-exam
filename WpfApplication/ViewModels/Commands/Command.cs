using System;
using System.Windows.Input;

namespace WpfApplication.ViewModels.Commands
{
    public class Command : ICommand
    {
        public Command(Action<object> executeDelegate, Predicate<object> canExecuteDelegate = null)
        {
            ExecuteDelegate = executeDelegate;
            CanExecuteDelegate = canExecuteDelegate;
        }
        
        public Action<object> ExecuteDelegate { get; set; }
        public Predicate<object> CanExecuteDelegate { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        
        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate is null || CanExecuteDelegate(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteDelegate?.Invoke(parameter);
        }
    }
}