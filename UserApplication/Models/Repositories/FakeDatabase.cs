using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserApplication.Models.Repositories
{
    public class FakeDatabase
    {
        public static List<User> GetAllPeople()
        {
            var users = new List<User>
                {
                    new User {Id = 1, Email = "my@mail.de", Name = "Tom"},
                    new User {Id = 2, Email = "32", Name = "Jane"},
                    new User {Id = 3, Email = "26", Name = "Frieda"},
                    new User {Id = 4, Email = "54", Name = "John"},
                    new User {Id = 5, Email = "52", Name = "Victor"},
                };

            return users;
        }
    }
}