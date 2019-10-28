using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace DepartmentOfCommerceProject.Infrastructure.Commands
{
    class FillTreeViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        readonly Action<object> execute;

        public FillTreeViewCommand(Action<object> execute = null)
        {
            this.execute = execute;
        }

        private bool GetConnectionState()
        {
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return GetConnectionState();
        }

        public void Execute(object parameter)
        {
            MessageBox.Show(parameter.GetType().ToString());
        }
    }
}
