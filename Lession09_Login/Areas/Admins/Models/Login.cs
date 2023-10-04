using System.ComponentModel.DataAnnotations;

namespace Lesson09_Login.Areas.Admins.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Địa chỉ Email không để trống")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không để trống")]
        public string Password { get; set; }
        public bool Rememberme { get; set; }
    }
}
