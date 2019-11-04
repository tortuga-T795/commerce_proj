using DepartmentOfCommerceProject.Infrastructure;
using DepartmentOfCommerceProject.Infrastructure.BusinessObjects;
using DepartmentOfCommerceProject.Infrastructure.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DepartmentOfCommerceProject.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<TreeViewNode> treeViewContent;
        private FillTreeViewCommand fillTreeViewCommand;
        private static SelectTreeViewItemCommand selectTreeViewItemCommand;

        // было изменено на обычное свойство из-за того, что лучше чтобы метод
        // OnProperyChanged вызывался именно тут, потому что в xaml, который в теории тоже может изменить 
        // значение свойства, нельзя просто так взять и вызвать метод из экземплята, так что теперь тут обычное свойство
        public ObservableCollection<TreeViewNode> TreeViewContent
        {
            get
            {
                if(treeViewContent == null)
                {
                    treeViewContent = new ObservableCollection<TreeViewNode>();
                }
                return treeViewContent;
            }
            set
            {
                treeViewContent = value;
                OnProperyChanged("TreeViewContent");
            }
        }

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

        public static ICommand SelectTreeViewItemCommand
        {
            get
            {
                if(selectTreeViewItemCommand == null)
                {
                    selectTreeViewItemCommand = new SelectTreeViewItemCommand((object obj) =>
                    {
                        MessageBox.Show(obj.ToString());
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
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
