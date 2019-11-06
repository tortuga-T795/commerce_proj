using ORM.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ORM.Util
{
    public class DatabaseDataSelectCondition<T> where T : DatabaseObject, new()
    {
        public PropertyInfo Property { get; private set; }
        public object Value { get; private set; }
        public ComparisonType ComparisonType { get; private set; }

        public DatabaseDataSelectCondition(PropertyInfo conditionProp, object condVal, ComparisonType compType)
        {
            Property = conditionProp;
            Value = condVal;
            ComparisonType = compType;
        }

        /// <summary>
        /// Getting correct condition to DatabaseData.Select(IEnumerable) method
        /// </summary>
        public string GetCondition()
        {
            return "";
        }

        public override string ToString()
        {
            return string.Format("Property: {0}\nValue: {1}\nComparisonType: {2}", Property, Value, ComparisonType);
        }
    }

    public enum ComparisonType
    {
        More,
        Less,
        Equal,
        NotEqual
    }
}
