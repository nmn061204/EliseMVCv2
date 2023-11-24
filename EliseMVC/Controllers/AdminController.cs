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
        public ActionResult ListUser()
        {
            return View(db.tblUsers.ToList());
        }
        public ActionResult Create()
        {        
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblUser user)
        {
            db.tblUsers.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View(db.tblUsers.Where(s => s.userID == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {

            return View(db.tblUsers.Where(s => s.userID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, tblUser user) 
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.tblUsers.Where(s => s.userID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, tblUser user)
        {
            user = db.tblUsers.Where(s => s.userID == id).FirstOrDefault();
            db.tblUsers.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}