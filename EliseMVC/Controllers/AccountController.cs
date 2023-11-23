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
    }
}