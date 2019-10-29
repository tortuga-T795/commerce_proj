using DepartmentOfCommerceProject.Infrastructure.BusinessObjects;
using DepartmentOfCommerceProject.Infrastructure.Commands;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace DepartmentOfCommerceProject.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public List<TreeViewNode> TreeViewContent { get; set; }
        private FillTreeViewCommand fillTreeViewCommand;

        public ICommand FillTreeViewCommand
        {
            get
            {
                if(fillTreeViewCommand == null)
                {
                    fillTreeViewCommand = new FillTreeViewCommand(ExecuteFillTreeViewCommand);
                }
                return fillTreeViewCommand;
            }
        }

        public ICommand SelectTreeViewItemCommand
        {
            get
            {
                return null;
            }
        }

        private void ExecuteFillTreeViewCommand(object parm)
        {
            Button btn = parm as Button;
            MessageBox.Show(btn.Name);
        }
    }
}
