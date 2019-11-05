using ORM.Repositories;
using ORM.Util;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace ORM.Objects
{
    public class DatabaseManager
    {
        #region Singleton
        private static readonly object lockObj = new object();
        private static DatabaseManager instance;

        [Obsolete]
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

        [Obsolete]
        public DatabaseManager()
        {
            ConnectionString = ConfigurationSettings.AppSettings.Get("mainDbConnectionString");
        }

        // DatabaseData<T>
        public void GetData<T, RepoType>(RepoType repo) where T : DatabaseObject, new() where RepoType : IRepository<T>
        {
            string tableName = typeof(T).GetTableName();
            string query = "SELECT * FROM " + tableName;
            DataSet dataSet = new DataSet();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.FillSchema(dataSet, SchemaType.Source, tableName);
                    adapter.Fill(dataSet, tableName);
                }

                connection.Close();
            }

            repo.Data = new DatabaseData<T>(dataSet);
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
