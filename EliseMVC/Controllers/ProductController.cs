using EliseMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EliseMVC.Controllers
{
    public class ProductController : Controller
    {
        DBEliseStoreEntitiess db = new DBEliseStoreEntitiess();
        // GET: Product
        private List<string> GetSizes()
        {
            return new List<string> { "S", "M", "L", "XL" };
        }
        public ActionResult Index()
        {
            return View(db.tblProducts.ToList());
        }
     
        public ActionResult Create()
        {
            tblProduct product = new tblProduct();
            product.ListOfSizes = GetSizes();
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(tblProduct product, List<string> selectedSizes)
        {
            try
            {
                if (product.imageProduct1 != null &&
                    product.imageProduct2 != null &&
                    product.imageProduct3 != null )
                {
                    string filename1 = Path.GetFileNameWithoutExtension(product.UploadImg1.FileName);
                    string filename2 = Path.GetFileNameWithoutExtension(product.UploadImg2.FileName);
                    string filename3 = Path.GetFileNameWithoutExtension(product.UploadImg3.FileName);                   



                    filename1 = filename1 + Path.GetExtension(product.UploadImg1.FileName);
                    product.imageProduct1 = "~/Content/Img/" + filename1;
                    filename2 = filename2 + Path.GetExtension(product.UploadImg2.FileName);
                    product.imageProduct2 = "~/Content/Img/" + filename2;
                    filename3 = filename3 + Path.GetExtension(product.UploadImg3.FileName);
                    product.imageProduct3 = "~/Content/Img/" + filename3;
                    


                    product.UploadImg1.SaveAs(Path.Combine(Server.MapPath("~/Content/Img/"), filename1));
                    product.UploadImg2.SaveAs(Path.Combine(Server.MapPath("~/Content/Img/"), filename2));
                    product.UploadImg3.SaveAs(Path.Combine(Server.MapPath("~/Content/Img/"), filename3));                                  
                }
                if (selectedSizes != null)
                {
                    // Lưu danh sách kích thước vào mô hình sản phẩm
                    product.sizePro = string.Join(",", selectedSizes);
                }
                db.tblProducts.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
        public ActionResult Details(int id)
        {
            return View(db.tblProducts.Where(s => s.ID == id).FirstOrDefault());
        }
        public ActionResult Edit(int? id)
        {

            return View(db.tblProducts.Where(s => s.ID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, tblProduct product)
        {
            try
            {
                if (product.imageProduct1 != null &&
                    product.imageProduct2 != null &&
                    product.imageProduct3 != null)
                {
                    string filename1 = Path.GetFileNameWithoutExtension(product.UploadImg1.FileName);
                    string filename2 = Path.GetFileNameWithoutExtension(product.UploadImg2.FileName);
                    string filename3 = Path.GetFileNameWithoutExtension(product.UploadImg3.FileName);



                    filename1 = filename1 + Path.GetExtension(product.UploadImg1.FileName);
                    product.imageProduct1 = "~/Content/Img/" + filename1;
                    filename2 = filename2 + Path.GetExtension(product.UploadImg2.FileName);
                    product.imageProduct2 = "~/Content/Img/" + filename2;
                    filename3 = filename3 + Path.GetExtension(product.UploadImg3.FileName);
                    product.imageProduct3 = "~/Content/Img/" + filename3;



                    product.UploadImg1.SaveAs(Path.Combine(Server.MapPath("~/Content/Img/"), filename1));
                    product.UploadImg2.SaveAs(Path.Combine(Server.MapPath("~/Content/Img/"), filename2));
                    product.UploadImg3.SaveAs(Path.Combine(Server.MapPath("~/Content/Img/"), filename3));                 
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
            { 
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View(db.tblProducts.Where(s => s.ID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, tblProduct product)
        {
            product = db.tblProducts.Where(s => s.ID == id).FirstOrDefault();
            db.tblProducts.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}