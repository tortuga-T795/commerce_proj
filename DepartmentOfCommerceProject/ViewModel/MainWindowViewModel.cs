using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DepartmentOfCommerceProject.Infrastructure.BusinessObjects;
using DepartmentOfCommerceProject.Infrastructure.Commands;

namespace DepartmentOfCommerceProject.ViewModel
{
    public class MainWindowViewModel
    {
        public List<TreeViewNode> TreeViewContent { get; set; }
        private FillTreeViewCommand fillTreeViewCommand;

        public ICommand FillTreeView
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
