using System.ComponentModel.DataAnnotations;

namespace TaskAuthenticationAuthorization.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Enter your email!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your First Name!")]
        [DataType(DataType.EmailAddress)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your Last Name!")]
        [DataType(DataType.EmailAddress)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [MaxLength(16)]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [MaxLength(16)]
        public string ConfirmPassword { get; set; }
    }
}