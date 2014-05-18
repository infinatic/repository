using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserApplication.Models;

namespace UserApplication.Models.Repositories
{
    public class UserRepository : Repository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = FakeDatabase.GetAllPeople();
        }

        public void Add(User User)
        {
            _users.Add(User);
        }

        public void Remove(User User)
        {
            _users.Remove(User);
        }

        // könnte FindBy(string key, value) sein
        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return _users.Where(predicate);
        }

        /// <summary>
        /// <para>
        /// This method will persist (create or update) an entity on the database
        /// using an auto-commit transaction
        /// </para>
        /// </summary>
        /// <param name="entity">The entity that is going to be persisted</param>
        public void Save(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(
                    "Entity can't be null");
            }

            if(user.Id == null)
            {
                Create(user);
            }
            else
            {
                Update(user);
            }
        }

        private void Update(User user)
        {
            throw new NotImplementedException();
        }

        private void Create(User user)
        {
            throw new NotImplementedException();
        }
    }
}