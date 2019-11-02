using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace DepartmentOfCommerceProject.Infrastructure.Commands
{
    class SelectTreeViewItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        private Action<object> execute;

        public SelectTreeViewItemCommand(Action<object> execute = null)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if((parameter as string).Equals("f"))
            {
                return;
            }
            execute.Invoke(parameter);
        }
    }
}
