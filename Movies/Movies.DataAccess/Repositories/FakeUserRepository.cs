using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Movies.DataAccess.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        public User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }
        private List<User> users = new List<User>
        {
            new User {Email = "abc@xxx.com", Password = "123", userName = "mba", Role = "Admin"},
            new User {Email = "defg@xxx.com", Password = "456", userName = "tas", Role = "Editor"},
            new User { Email = "ghi@xxx.com", Password = "789",userName = "sayrim", Role = "User" },
        };
        
        public IList<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetWithCriteria(Func<User, bool> criteria)
        {
            return users.Where(criteria).ToList();
        }

        public User Update(User genre)
        {
            throw new NotImplementedException();
        }
    }
}
