using System;
using System.Windows.Input;

namespace AutoArchivePlus.Command
{
    internal class ControlCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> executeMethod;

        public ControlCommand(Action<object> executeMethod)
        {
            this.executeMethod = executeMethod;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeMethod?.Invoke(parameter);
        }
    }
}
