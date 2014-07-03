using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserApplication.Models;

namespace UserApplication.Models.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public override string Tablename { 
            get
            {
                return "User";
            }
        }

        public override void Insert(User user)
        {
            throw new NotImplementedException();
        }

        public override void Update(User user)
        {
            throw new NotImplementedException();
        }

        public override bool IsEntityNew(User user)
        {
            return true;
        }

        /// <summary>
        ///     Defines how to create entity object from database result.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public override User Map(IDataRecord record)
        {
            User u = new User();
            u.Id = (int)record["Id"];
            u.Name = record["name"] as string;
            u.Email = record["email"] as string;
            return u;
        }
    }
}