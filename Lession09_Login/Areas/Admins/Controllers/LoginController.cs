using Lesson09_Login.Areas.Admins.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Lesson09_Login.Models;
using System.Text;
using XSystem.Security.Cryptography;

namespace Lesson09_Login.Areas.Admins.Controllers
{
    //[Area("Admins")]
    public class LoginController : Controller
    {
        private readonly DevXuongMocContext _context;
        public LoginController(DevXuongMocContext context)
        {
            _context = context;
        }
        [HttpGet] // Get, hiển thị form để nhập dữ liệu
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]   // POST-> khi submit form
        public IActionResult Index(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // trả về trạng thái lỗi
            }
            //// sẽ xử lý logic phần đăng nhập tại đây
            var pass = GetSHA26Hash(model.Password);
            var dataLogin = _context.AdminUsers.Where(x => x.Email.Equals(model.Email) && x.Password.Equals(pass)).FirstOrDefault();
            if (dataLogin != null)
            {
                // Lưu session khi đăng nhập thành công
                HttpContext.Session.SetString("AdminLogin", model.Email);
                //HttpContext.Session.SetString("AdminUsers", dataLogin.ToJson());
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model); // trả về trạng thái lỗi
        }

        [HttpGet] // Thoát đăng nhập, hủy session
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminLogin"); // Hủy session với key AdminLogin đã lưu trước đó
            return RedirectToAction("Index");
        }
        static string GetSHA26Hash(string input)
        {
            string hash = "";
            using (var sha256 = new SHA256Managed())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
            return hash;
        }
    }

}
