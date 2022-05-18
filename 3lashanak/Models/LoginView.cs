using System.ComponentModel.DataAnnotations;

namespace _3lashanak.Models
{
    public class LoginView
    {
        [Required]
        [UIHint("username")]
        public string UserName { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
