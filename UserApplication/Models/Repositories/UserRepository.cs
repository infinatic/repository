using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserApplication.Models;

namespace UserApplication.Models.Repositories
{
    public class UserRepository : Repository<User>
    {
        public void Save(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(
                    "Entity can't be null");
            }

            if(user.Id == null)
            {
                Create(user, this.GetTestDbConnection());
            }
            else
            {
                Update(user, this.GetTestDbConnection());
            }
        }

        private void Create(User user, SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        private void Update(User user, SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Defines how to create entity object from database result.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public override User Map(IDataRecord record)
        {
            User u = new User();
            u.Id = (DBNull.Value == record["Id"]) ?
                null : (int?)record["Id"];

            u.Name = (DBNull.Value == record["name"]) ?
                string.Empty : (string)record["name"];

            u.Email = (DBNull.Value == record["email"]) ?
                string.Empty : (string)record["email"];

            return u;
        }
    }
}