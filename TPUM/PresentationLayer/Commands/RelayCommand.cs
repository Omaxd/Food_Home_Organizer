using System;
using System.Windows.Input;

namespace PresentationLayer.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action _action;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action.Invoke();
        }
    }
}