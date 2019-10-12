using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentOfCommerceProject.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected ViewModelBase()
        { }

        public virtual void OnProperyChanged(string propName)
        {
            PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
            if (propertyChangedEventHandler != null)
            {
                propertyChangedEventHandler.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
