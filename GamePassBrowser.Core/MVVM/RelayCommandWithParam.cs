using System;
using System.Windows.Input;

namespace GamePassBrowser.Core.MVVM
{
    public class RelayCommandWithParam<T> : ICommand
    {
        private readonly Action<T> _action;
        private readonly Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public RelayCommandWithParam(Action<T> action)
        {
            _action = action;
        }

        public RelayCommandWithParam(Action<T> action, Func<bool> canExecute) : this(action)
        {
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter = null)
            => _canExecute == null || _canExecute.Invoke();

        public void Execute(object parameter)
        {
            if (parameter is T param)
                _action(param);

            else
                throw new ArgumentException($"Parameter was not of expected type - {typeof(T)}", nameof(param));
        }
    }
}