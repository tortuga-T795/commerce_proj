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
                row = value ?? throw new ArgumentException(string.Format("In setter of {0}.Row value is null", GetType()));
            }
        }

        public void Attach(DataRow row)
        {
            this.Row = row;

            PropertyInfo[] propertyes = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in propertyes)
            {
                FieldNameAttribute attribute = property.GetCustomAttribute<FieldNameAttribute>(true);
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
                FieldNameAttribute attribute = property.GetCustomAttribute<FieldNameAttribute>(true);
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

        /// <summary>
        /// Geting valid condition to select row from DataTable
        /// </summary>
        public string GetCondition()
        {
            PropertyInfo primaryKeyProperty = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where((info) =>
            {
                PrimaryKeyAttribute attr = info.GetCustomAttribute<PrimaryKeyAttribute>(true);
                return attr == null;
            }).Last();
            string primaryKeyFieldName = primaryKeyProperty.GetCustomAttribute<FieldNameAttribute>(true).Name;

            string res = primaryKeyFieldName + " = ";

            res += primaryKeyProperty.PropertyType == typeof(string) ? string.Format("'{0}'", primaryKeyProperty.GetValue(this).ToString()) : primaryKeyProperty.GetValue(this).ToString();

            return res;
        }
    }
}
