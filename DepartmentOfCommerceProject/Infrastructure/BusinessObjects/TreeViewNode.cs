using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DepartmentOfCommerceProject.Infrastructure.BusinessObjects
{
    public class TreeViewNode
    {
        public string ItemText { get; set; }

        public BitmapImage ItemImage { get; set; }

        public List<TreeViewNode> Nodes { get; set; }
    }
}
