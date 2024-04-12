using Microsoft.AspNetCore.Mvc;
using Midterm_Assignment1_Login.Presentation.ViewModels;

namespace Midterm_Assignment1_Login.Presentation.Controllers
{
    public class AccountController : Controller
    {
      
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
    
                return RedirectToAction("Account", "Login"); 
            }
            return View(model); 
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


}
