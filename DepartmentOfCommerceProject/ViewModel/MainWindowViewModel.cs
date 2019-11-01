using DepartmentOfCommerceProject.Infrastructure.BusinessObjects;
using DepartmentOfCommerceProject.Infrastructure.Commands;
using DepartmentOfCommerceProject.Infrastructure;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace DepartmentOfCommerceProject.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<TreeViewNode> TreeViewContent { get; private set; }

        private FillTreeViewCommand fillTreeViewCommand;
        private SelectTreeViewItemCommand selectTreeViewItemCommand;

        public ICommand FillTreeViewCommand
        {
            get
            {
                if (fillTreeViewCommand == null)
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
                if(selectTreeViewItemCommand == null)
                {
                    selectTreeViewItemCommand = new SelectTreeViewItemCommand((object obj) =>
                    {
                        System.Windows.MessageBox.Show(obj.ToString());
                    });
                }
                return selectTreeViewItemCommand;
            }
        }

        private void ExecuteFillTreeViewCommand(object parm)
        {
            Button btn = parm as Button;
            string name = btn.Name;
            try
            {
                TreeViewContent = TreeViewData.Data[name];
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            OnProperyChanged("TreeViewContent");
        }
    }
}
