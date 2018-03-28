using System;
using System.Windows.Input;

namespace WPF_MVVM_example.UI.Commands
{
    class RelayCommandT1<T> : ICommand
    {
        private Predicate<T> _canExecute;
        private Action<T> _execute;

        public RelayCommandT1(Predicate<T> canExecute, Action<T> execute)
        {
            this._canExecute = canExecute;
            this._execute = execute;
        }

        public RelayCommandT1(Action<T> execute) : this((T) => { return true; }, execute)
        { }

        bool ICommand.CanExecute(object parameter)
        {
            if (parameter == null)
                return false;

            return CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(T parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(T parameter)
        {
            _execute(parameter);
        }
    }
}
