using System;
using System.Reflection.Metadata;
using System.Windows.Input;

namespace PresentationLayer.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _action;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> action)
        {
            _action = action;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action.Invoke(parameter);
        }
    }
}