using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ORM.Util;

namespace ORM.Objects
{
    public class DatabaseData<T> where T : DatabaseObject, new()
    {
        public DataSet Data { get; private set; }
        private string TableName { get; set; }

        public DatabaseData(DataSet set)
        {
            this.Data = set;
            this.TableName = typeof(T).GetTableName();
        }

        public IEnumerable<T> Select()
        {
            return this.Select("");
        }

        public IEnumerable<T> Select(string condition)
        {
            List<T> res = new List<T>();

            DataRow[] rows = this.Data.Tables[this.TableName].Select(condition);

            foreach (DataRow row in rows)
            {
                T newItem = new T();
                newItem.Attach(row);
                res.Add(newItem);
            }

            return res;
        }

        public T Create(T obj)
        {
            DataRow newRow = this.Data.Tables[this.TableName].NewRow();

            obj.Row = newRow;
            obj.Commit();

            this.Data.Tables[this.TableName].Rows.Add(newRow);

            return obj;
        }

        public void Delete(T obj)
        {
            string condition = obj.GetCondition();
            DataRow row = this.Data.Tables[this.TableName].Select(condition)[0];

            row.Delete();
        }

        public void Edit(T obj)
        {
            string condition = obj.GetCondition();
            DataRow row = this.Data.Tables[this.TableName].Select(condition)[0];

            obj.Commit();

            row.ItemArray = obj.Row.ItemArray;
            // сия параща нах не сдалась, но это ещё не точно)
            //// это тоже хз работает ли, но прикол тут в том, что данные изменённого объекта
            //// записываются в его Row, и потом нужно изменить эти данные в DataSet'е ну и вот
            //for (int i = 0; i < row.ItemArray.Length; ++i)
            //{
            //    row.ItemArray[i] = obj.Row.ItemArray[i];
            //}
            // может и эта параша бы работала, но лучше написать пока не потерял идею)
            //row = obj.Row;
        }
    }
}
