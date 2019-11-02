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
        public event EventHandler CanExecuteChanged;

        private Action<object> execute;
        private List<string> ignoreList;

        public SelectTreeViewItemCommand(Action<object> execute = null)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            //string prm = parameter as string;
            //return prm.Substring(0, )
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
