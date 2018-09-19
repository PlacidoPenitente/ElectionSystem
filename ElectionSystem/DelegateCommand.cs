using System;
using System.Windows.Input;

namespace ElectionSystem
{
    public sealed class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged = (sender, obj) => { };

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
