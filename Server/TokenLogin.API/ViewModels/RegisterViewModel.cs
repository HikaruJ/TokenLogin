using System.ComponentModel.DataAnnotations;

namespace MailOnRails.API
{
    public class RegisterViewModel
    {
        public LoginActions Action { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirm password should match")]
        [MinLength(6, ErrorMessage = "Password should contain at least 6 characters")]
        public string Password { get; set; }
        public string UserName { get; set; }
    }

    public enum LoginActions
    {
        Login,
        Register,
        LogOff

    }
}