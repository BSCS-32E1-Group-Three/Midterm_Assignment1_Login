using Microsoft.AspNetCore.Mvc;
using Midterm_Assignment1_Login.Core.Models;
using Midterm_Assignment1_Login.Presentation.ViewModels;

namespace Midterm_Assignment1_Login.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Login logic
                return RedirectToAction("Index", "Home"); // Redirect to home page after successful login
            }
            return View(model); // Return the view with errors if model state is not valid
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Registration logic
                return RedirectToAction("Index", "Home"); // Redirect to home page after successful registration
            }
            return View(model); // Return the view with errors if model state is not valid
        }
    }

    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        void CreateUser(User user);
    }
}
