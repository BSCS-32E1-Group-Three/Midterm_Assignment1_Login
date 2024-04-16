using Microsoft.AspNetCore.Mvc;
using Midterm_Assignment1_Login.Interfaces;
using Midterm_Assignment1_Login.Models;
using Midterm_Assignment1_Login.Presentation.ViewModels;

namespace Midterm_Assignment1_Login.Controllers
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
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user != null && user.Password == password)
            {
                // Authentication successful, redirect to dashboard or another page
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid username or password.");
            return View();

        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new user
                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password // Make sure to hash and salt the password in a real application
                };

                // Add the user to the repository
                _userRepository.CreateUser(user);

                // Redirect to the login page
                return RedirectToAction("Login");
            }

            // If the model state is not valid, return the register view with the model to display validation errors
            return View(model);
        }



    }
}
