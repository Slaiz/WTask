using System;
using System.Windows.Input;

namespace Shared
{
    public class CommandHandler : ICommand
    {
        public CommandHandler(Action<object> action)
        {
            ExecuteDelegate = action;
        }

        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
            {
                return CanExecuteDelegate(parameter);
            }

            return true;
        }

        public void Execute(object parameter)
        {
            ExecuteDelegate?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}