using Midterm_Assignment1_Login.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Midterm_Assignment1_Login.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }

        public void CreateUser(User user)
        {
            _users.Add(user);
        }
    }

    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        void CreateUser(User user);
    }
}
