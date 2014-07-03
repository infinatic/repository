using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public abstract class BaseRepository<TEntity>
        where TEntity : class, new()
    {
        public abstract string Tablename { get; }

        public IList<TEntity> FindBy(string key, string value)
        {
            IList<TEntity> result = new List<TEntity>();

            // TODO have to pass the key as param 
            string query = "select * from " + this.Tablename + " Where " + key + " = @value";

            using (SqlConnection connection = GetTestDbConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", value);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(this.Map(reader));
                }
                reader.Close();
            }
            return result;
        }


        public void Save(TEntity entity)
        {
            if (this.IsEntityNew(entity))
            {
                this.Insert(entity);
            }
            else
            {
                this.Update(entity);
            }
        }


        public SqlConnection GetTestDbConnection()
        {
            string connectionString =
                "Data Source=(localdb)\\Projects;Initial Catalog=UserDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            return new SqlConnection(connectionString);
        }

        public abstract TEntity Map(IDataRecord record);
        public abstract void Update(TEntity entity);
        public abstract void Insert(TEntity entity);
        public abstract bool IsEntityNew(TEntity entity);
    }
}