using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DepartmentOfCommerceProject.ViewModel;

namespace DepartmentOfCommerceProject.Infrastructure.BusinessObjects
{
    public enum IconType
    {
        Folder,
        Item
    }

    public class TreeViewNode
    {
        public TreeViewNode(string itemText, IconType iconType, ObservableCollection<TreeViewNode> nodes = null)
        {
            this.ItemText = itemText;
            this.IconType = iconType;
            this.Nodes = nodes;
        }

        public string ItemText { get; private set; }

        public string CommandParameter { get; set; } = "f"; // потом надо будет добавить private к set'у

        public IconType IconType { get; private set; }

        public ObservableCollection<TreeViewNode> Nodes { get; private set; }

        /// <summary>
        /// КАСТЫЫЫЫЫЫЫЛЬ
        /// Логика сия говна такова: в MainWindowViewModel валяется команда, но биндингом её не видно в элементе
        /// TreeView, из-за того, что они байндят эти объеты и команды из ViewModel
        /// </summary>
        public ICommand Command
        {
            get
            {
                return MainWindowViewModel.SelectTreeViewItemCommand;
            }
        }
    }
}
