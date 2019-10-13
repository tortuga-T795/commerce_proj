using ORM.Util;
using System.Data;
using System.Data.SqlClient;

namespace ORM.Objects
{
    public class DatabaseManager
    {
        private string ConnectionString { get; set; }

        public DatabaseManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DatabaseData<T> GetData<T>() where T : DatabaseObject, new()
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

            return new DatabaseData<T>(dataSet);
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
