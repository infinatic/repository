using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public abstract class Repository<TEntity>
        where TEntity : class, new()
    {
        public IList<TEntity> FindBy(string key, string value)
        {
            IList<TEntity> result = new List<TEntity>();

            string query = "select * from dbo.[User] Where "+key+" = @value";

            using (SqlConnection connection = GetTestDbConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", value);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(Map(reader));
                }
                reader.Close();

            }
            return result;
        }

        public SqlConnection GetTestDbConnection()
        {
            string connectionString =
                "Data Source=(localdb)\\Projects;Initial Catalog=UserDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            return new SqlConnection(connectionString);
        }

        abstract public TEntity Map(IDataRecord record);
    }
}