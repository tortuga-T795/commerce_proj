using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DepartmentOfCommerceProject.ViewModel;

namespace DepartmentOfCommerceProject.Infrastructure.BusinessObjects
{
    public enum IconType
    {
        folder,
        item
    }

    public class TreeViewNode
    {
        public TreeViewNode(string itemText, IconType iconType, ObservableCollection<TreeViewNode> nodes = null)
        {
            this.ItemText = itemText;
            this.IconType = iconType;
            this.Nodes = nodes;

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();
            Random rand = new Random();
            CommandParameter = new string(Enumerable.Repeat(chars, 10).Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        public string ItemText { get; private set; }

        public string CommandParameter { get; private set; }

        public IconType IconType { get; private set; }

        public ObservableCollection<TreeViewNode> Nodes { get; private set; }

        /// <summary>
        /// КАСТЫЫЫЫЫЫЫЛЬ
        /// Логика сия говна такова: в MainWindowViewModel валяется команда, но биндингом её не видно в элементе
        /// TreeView, из-за того, что они байндят эти объеты и команды из ViewModel не видно
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
