using System.ComponentModel.DataAnnotations;

namespace TaskAuthenticationAuthorization.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter your email!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Enter your password!")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [MaxLength(16)]
        public string Password { get; set; }
    }
}