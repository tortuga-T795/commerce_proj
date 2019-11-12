using ORM.Repositories;
using ORM.Util;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Reflection;

namespace ORM.Objects
{
    public sealed class DatabaseManager
    {
        #region Singleton
        private static readonly object lockObj = new object();
        private static DatabaseManager instance;

        public static DatabaseManager Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseManager();
                    }
                    return instance;
                }
            }
        }
        #endregion

        private string ConnectionString { get; set; }

        public DatabaseManager()
        {
            ConnectionString = ConfigurationManager.AppSettings["mainDbConnectionString"];
        }

        private DataSet LoadDataByQuery(string query, string tableName)
        {
            DataSet res = new DataSet();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.FillSchema(res, SchemaType.Source, tableName);
                    adapter.Fill(res, tableName);
                }

                connection.Close();
            }

            return res;
        }

        // DatabaseData<T>
        public void GetData<T, RepoType>(RepoType repo) where T : DatabaseObject, new() where RepoType : IRepository<T>
        {
            string tableName = typeof(T).GetTableName();
            string query = "SELECT * FROM " + tableName;
            DataSet set = LoadDataByQuery(query, tableName);

            repo.Data = new DatabaseData<T>(set);
        }

        /// <summary>
        /// Selected data from table by equals of conditionProp property
        /// </summary>
        /// <typeparam name="T">Needed DatabaseObject</typeparam>
        /// <param name="conditionProp">Property to create SELECT condition</param>
        /// <param name="conditionPropValue">value of condition property</param>
        public DatabaseData<T> GetData<T>(PropertyInfo conditionProp, object conditionPropValue) where T : DatabaseObject, new()
        {
            string tableName = typeof(T).GetTableName();
            string fieldName = conditionProp.GetFieldName();

            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }
            else if (fieldName == null)
            {
                throw new ArgumentNullException("fieldName");
            }

            T condInstance = new T();
            conditionProp.SetValue(condInstance, conditionPropValue, null);
            string query = "SELECT * FROM " + tableName + " WHERE " + fieldName + " = " + conditionProp.GetValidToConditionFieldValue(condInstance);

            DataSet set = LoadDataByQuery(query, tableName);

            return new DatabaseData<T>(set);
        }

        public void Commit<T>(DatabaseData<T> data) where T : DatabaseObject, new()
        {
            string tableName = typeof(T).GetTableName();
            string selectQuery = "SELECT * FROM " + tableName + " WHERE ROWNUM = 1";

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))
                {
                    using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                    {
                        adapter.Update(data.Data, tableName);
                    }
                }

                connection.Close();
            }
        }
    }
}
