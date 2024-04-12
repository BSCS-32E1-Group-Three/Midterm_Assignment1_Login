using System.ComponentModel.DataAnnotations;

namespace Midterm_Assignment1_Login.Presentation.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
