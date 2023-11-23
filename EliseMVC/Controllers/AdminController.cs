using EliseMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ActionResult Login(tblUser model)
        {
            if (ModelState.IsValid)
               
            {
                using (var db = new DBEliseStoreEntitiess())
                {
                    // Kiểm tra thông tin đăng nhập từ cơ sở dữ liệu
                    var user = db.tblUsers.FirstOrDefault(u => u.userName == model.userName && u.userPass == model.userPass);

                    if (user != null)
                    {
                        // Đăng nhập thành công
                        // Thực hiện lưu thông tin đăng nhập vào Session hoặc Cookie nếu cần
                        FormsAuthentication.SetAuthCookie(user.userName, false);

                        // Chuyển hướng đến trang Admin hoặc trang chính
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        // Đăng nhập không thành công, thêm thông báo lỗi vào ModelState
                        ModelState.AddModelError("", "Thông tin đăng nhập không đúng");
                    }
                }
               
            }
            return View();
        }
    }
}