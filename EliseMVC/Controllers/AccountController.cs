using EliseMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EliseMVC.Controllers
{
    public class AccountController : Controller
    {
        DBEliseStoreEntitiess db = new DBEliseStoreEntitiess();
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblUser model)
        {
            if (ModelState.IsValid)
            {
                var user = db.tblUsers.FirstOrDefault(u => u.userName == model.userName && u.userPass == model.userPass);

                if (user != null)
                {
                    // Đăng nhập thành công
                    FormsAuthentication.SetAuthCookie(user.userName, false);

                    // Kiểm tra và chuyển hướng người dùng có role là "admin"
                    if (user.userRole == "admin" || user.userRole == "staff")
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        // Chuyển hướng người dùng có role khác (nếu cần)
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin đăng nhập không đúng");
                }
            }

            // Đăng nhập không thành công, hiển thị lại form đăng nhập với thông báo lỗi
            return View(model);
        }
    }
}