using Midterm_Assignment1_Login.Models;

namespace Midterm_Assignment1_Login.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        void CreateUser(User user);
    }
}
