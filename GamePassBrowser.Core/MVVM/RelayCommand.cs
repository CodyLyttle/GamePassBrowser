using System;
using System.Windows.Input;

namespace GamePassBrowser.Core.MVVM
{
    public class RelayCommand : ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;
        
        public RelayCommand(Action action)
        {
            _action = action;
        }

        public RelayCommand(Action action, Func<bool> canExecute) : this(action)
        {
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter = null)
        {
            return _canExecute == null || _canExecute.Invoke();
        }

        public void Execute(object parameter = null)
        {
            _action.Invoke();
        }
    }
}