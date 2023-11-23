using EliseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace EliseMVC.Controllers
{
    public class HomeController : Controller
    {
       DBEliseStoreEntitiess db = new DBEliseStoreEntitiess();
        // GET: Home
        public ActionResult Index()
        {
            var products = db.tblProducts.Take(12).ToList();
            return View(products);
        }
        public ActionResult AllProduct()
        {
            return View(db.tblProducts.ToList());
        }
        public ActionResult Search(string searchTerm)
        {

            // Kiểm tra có null hay rỗng hay không.
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // trả về kết quả là một danh sách mãnh rỗng.
                return PartialView("_SearchResultsPartialView", new List<tblProduct>());
            }

            // tìm sản phẩm với tên sản phẩm trùng với searchTerm.
            var searchResults = db.tblProducts
                .Where(p => p.nameProduct.Contains(searchTerm))
                .ToList();


            // trả kết quả danh sách sản phẩm tìm được.
            return PartialView("_SearchResultsPartialView", searchResults);
        }
        public ActionResult ProductDetail(string id)
        {
            var product = db.tblProducts.FirstOrDefault(p => p.ID.ToString() == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
    }
}