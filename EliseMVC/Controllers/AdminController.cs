using EliseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EliseMVC.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        DBEliseStoreEntitiess db = new DBEliseStoreEntitiess();
        // GET: Admin

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string userPass)
        {
            var user = db.tblUsers.FirstOrDefault(u => u.userName == userName && u.userPass == userPass);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                System.Diagnostics.Debug.WriteLine("User is authenticated: " + User.Identity.IsAuthenticated);
                // Đăng nhập thành công, có thể thực hiện các hành động khác ở đây
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return View("Login");
            }
        }
    }
}