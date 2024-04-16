using System.Reflection;

namespace Midterm_Assignment1_Login.Models
{
    public class User
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User()
        {
      
        }
    }
}
