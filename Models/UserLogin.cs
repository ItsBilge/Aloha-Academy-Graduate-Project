using System.ComponentModel.DataAnnotations;

namespace Aloha_Academy_Graduate_Project.Models
{
    public class UserLogin
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
