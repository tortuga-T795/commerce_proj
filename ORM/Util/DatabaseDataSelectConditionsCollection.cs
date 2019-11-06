using ORM.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Util
{
    public class DatabaseDataSelectConditionsCollection<T> where T : DatabaseObject, new()
    {
        public List<DatabaseDataSelectCondition<T>> Conditions { get; private set; }
        public List<LogicOperator> Operators { get; private set; }

        public DatabaseDataSelectConditionsCollection(
            List<DatabaseDataSelectCondition<T>> conditions,
            List<LogicOperator> operators)
        {
            if(conditions.Count != operators.Count + 1)
            {
                throw new ArgumentException("incorrect count of conditions or operators");
            }

            Conditions = conditions;
            Operators = operators;
        }

        public void AddCondition(DatabaseDataSelectCondition<T> condition, LogicOperator lOperator)
        {
            Conditions.Add(condition);
            Operators.Add(lOperator);
        }

        public string GetCondition()
        {
            string res = Conditions.First().GetCondition();

            for(int i = 0; i < Operators.Count; ++i)
            {
                res += Operators[i] == LogicOperator.Or ? " OR " : " AND ";
                res += Conditions[i + 1].GetCondition();
            }

            return res;
        }
    }

    public enum LogicOperator
    {
        Or,
        And
    }
}
