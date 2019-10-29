using System.Collections.ObjectModel;

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
        }

        public string ItemText { get; private set; }

        public IconType IconType { get; private set; }

        public ObservableCollection<TreeViewNode> Nodes { get; private set; }
    }
}
