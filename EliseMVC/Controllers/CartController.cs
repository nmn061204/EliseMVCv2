using EliseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EliseMVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        DBEliseStoreEntitiess db = new DBEliseStoreEntitiess();
        public ActionResult Cart()
        {
            return View(db.tblProducts.ToList());
        }
    }
}