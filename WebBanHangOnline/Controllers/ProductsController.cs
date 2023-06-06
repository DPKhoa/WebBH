using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index(string SearchText)
        {
            var items = db.Products.ToList();
            //IEnumerable<Product> items = db.Products.OrderByDescending(x => x.Id);
            //if (!string.IsNullOrEmpty(SearchText))
            //{
            //    items = items.Where(x => x.Alias.Contains(SearchText) || x.Title.Contains(SearchText));
            //}

            return View(items);
        }
        public ActionResult Detail(string alias, int id)
        {
            var items = db.Products.Find(id);
            if(items != null)
            {
                db.Products.Attach(items);
                items.ViewCount = items.ViewCount + 1;
                db.Entry(items).Property(x=>x.ViewCount).IsModified = true;
                db.SaveChanges();

            }
            items.ViewCount = items.ViewCount + 1;
            return View(items);
        }
        public ActionResult ProductCategory(string alias ,int? id)
        {
            var items = db.Products.ToList();
            if (id >0)
            {
                items = items.Where(x => x.ProductCategoryId == id).ToList();
            }
            var cate = db.ProductCategories.Find(id);
            if(cate != null)
            {
                ViewBag.CateName = cate.Title;
            }
            ViewBag.CateId = id;
            return View(items);
        }
        public ActionResult Partial_ItemsByCateId()
        {
            var items = db.Products.Where(x=>x.IsHome && x.IsActived).Take(12).ToList();  
            return PartialView(items);  
        }
        public ActionResult Partial_ProductSales()
        {
            var items = db.Products.Where(x => x.IsSale && x.IsActived).Take(12).ToList();
            return PartialView(items);
        }
    }
}