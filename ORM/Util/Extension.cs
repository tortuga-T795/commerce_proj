using ORM.Attributes;
using ORM.Objects;
using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace ORM.Util
{
    public static class Extension
    {
        public static string GetTableName(this Type type)
        {
            TableNameAttribute attribute = type.GetCustomAttribute<TableNameAttribute>(true);

            if(attribute == null)
            {
                return null;
            }

            return attribute.Name;
        }

        public static PropertyInfo GetPublicProperty(this object obj, string propName)
        {
            return obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// Сие говницо не факт что работает, потому что проверить это можно на готовом проекте с подключением к бд,
        /// а так как мне в падлу сейчас это делать, то сделаю потом :)
        /// 
        /// PыSы А не работать эта параша может из-за того, что зуй знает, 
        /// правильно ли определится равенство объектов на 36 строке
        /// </summary>
        /// <returns></returns>
        public static bool RowsEquals(this DataRow row, DataRow otherRow)
        {
            if(row.ItemArray.Length != otherRow.ItemArray.Length)
            {
                return false;
            }

            bool res = true;
            for(int i = 0; i < row.ItemArray.Length; ++i)
            {
                res &= row[i] == otherRow[i];
            }

            return res;
        }

        /// <summary>
        /// Getting field name from DatabaseObject property
        /// </summary>
        /// <param name="propInfo"></param>
        /// <returns></returns>
        public static string GetFieldName(this PropertyInfo propInfo)
        {
            FieldNameAttribute attr = propInfo.GetCustomAttribute<FieldNameAttribute>();

            if(attr == null)
            {
                return null;
            }

            return attr.Name;
        }

        public static string GetValidToConditionFieldValue(this PropertyInfo propInfo, DatabaseObject obj)
        {
            if(propInfo.PropertyType == typeof(string))
            {
                return "'" + propInfo.GetValue(obj, null).ToString() + "'";
            }

            return propInfo.GetValue(obj, null).ToString();
        }

        public static string GetValidToConditionValue(this object obj)
        {
            if (obj.GetType() == typeof(string))
            {
                return "'" + obj.ToString() + "'";
            }

            return obj.ToString();
        }
    }
}
