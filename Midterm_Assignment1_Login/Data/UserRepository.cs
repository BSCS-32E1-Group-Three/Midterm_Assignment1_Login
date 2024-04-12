using System.Collections.Generic;
using System.Linq;
using Midterm_Assignment1_Login.Interfaces;
using Midterm_Assignment1_Login.Models;

namespace Midterm_Assignment1_Login.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();


        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            }

            User? user = _users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                throw new InvalidOperationException("User not found."); // Or handle this case as appropriate
            }

            return user;
        }


        public void CreateUser(User user)
        {
            _users.Add(user);
        }
    }
}
