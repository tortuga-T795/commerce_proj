using System;
using System.Linq;
using System.Data;
using System.Reflection;
using ORM.Attributes;

namespace ORM.Objects
{
    public class DatabaseObject
    {
        private DataRow row;
        public DataRow Row
        {
            get
            {
                return row;
            }
            set
            {
                // ыы
                // вижла подсказала, сам я слишком тупой чтобы так написать)))
                row = value ?? throw new ArgumentException(string.Format("In setter of {0}.Row value is null", GetType().ToString()));
            }
        }

        public void Attach(DataRow row)
        {
            this.Row = row;

            PropertyInfo[] propertyes = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in propertyes)
            {
                FieldNameAttribute attribute = property.GetCustomAttributes(typeof(FieldNameAttribute), true).FirstOrDefault() as FieldNameAttribute;
                if (attribute == null)
                {
                    continue;
                }
                property.SetValue(this, row[attribute.Name], null);
            }
        }

        public void Commit()
        {
            PropertyInfo[] propertyes = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in propertyes)
            {
                FieldNameAttribute attribute = property.GetCustomAttributes(typeof(FieldNameAttribute), true).FirstOrDefault() as FieldNameAttribute;
                if (attribute == null)
                {
                    continue;
                }
                this.Row[attribute.Name] = property.GetValue(this, null);
            }
        }

        public void Rollback()
        {
            this.Attach(this.Row);
        }
    }
}
