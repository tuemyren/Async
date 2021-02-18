using System;
using System.Windows.Input;

namespace AsyncKata1
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> m_Execute;
        private readonly Predicate<object> m_CanExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            m_Execute = execute;
            m_CanExecute = canExecute;
        }

        public bool CanExecute(object parameter) => m_CanExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => m_Execute?.Invoke(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
