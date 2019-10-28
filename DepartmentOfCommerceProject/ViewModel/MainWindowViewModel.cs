using DepartmentOfCommerceProject.Infrastructure.BusinessObjects;
using DepartmentOfCommerceProject.Infrastructure.Commands;
using System.Collections.Generic;
using System.Windows.Input;

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
                    fillTreeViewCommand = new FillTreeViewCommand();
                }
                return fillTreeViewCommand;
            }
        }
    }
}
