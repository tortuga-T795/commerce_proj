using DepartmentOfCommerceProject.Infrastructure.BusinessObjects;
using DepartmentOfCommerceProject.Infrastructure.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DepartmentOfCommerceProject.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<TreeViewNode> TreeViewContent { get; private set; } = new ObservableCollection<TreeViewNode>()
        {
            new TreeViewNode("pipidastr", IconType.folder, new ObservableCollection<TreeViewNode>()
            {
                new TreeViewNode("pipidastr1", IconType.item)
            })
        };
        private FillTreeViewCommand fillTreeViewCommand;

        private Dictionary<string, ObservableCollection<TreeViewNode>> TreeViewData = new Dictionary<string, ObservableCollection<TreeViewNode>>()
        {
            { "desktopButton", new ObservableCollection<TreeViewNode>()
                {
                    new TreeViewNode("pipidastr2", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("pipidastr3", IconType.item)
                    })
                }
            }
        };

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
                return null;
            }
        }

        private void ExecuteFillTreeViewCommand(object parm)
        {
            Button btn = parm as Button;
            TreeViewContent = TreeViewData[btn.Name];
            OnProperyChanged("TreeViewContent");
        }
    }
}
