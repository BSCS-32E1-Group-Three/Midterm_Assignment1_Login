using Microsoft.AspNetCore.Mvc;
using Midterm_Assignment1_Login.Interfaces;
using Midterm_Assignment1_Login.Models;
using Midterm_Assignment1_Login.Presentation.ViewModels;
using BCrypt.Net;


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
        //LOGIN PR
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user != null)
            {
                // Verify the password using bcrypt
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    // Authentication successful, redirect to dashboard or another page
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }
        //REGISTER PR
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                // Hash the password using bcrypt before storing it
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

                // Create a new user with hashed password
                var user = new User { Username = model.Username, Password = hashedPassword };

                _userRepository.CreateUser(user);

                // Redirect to the login page
                return RedirectToAction("Login");
            }

            // If the model state is not valid, return the register view with the model to display validation errors
            return View(model);
        }




    }
}
