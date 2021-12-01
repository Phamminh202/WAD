using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T2010A_WAD.Models;

namespace T2010A_WAD.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private DataContext context = new DataContext();
        public ActionResult Index()
        {
            var list = context.Products.ToList();
            return View(list);
        }
        public ActionResult CreateNew()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew(Product product)
        {
            if (ModelState.IsValid)
            {
                // khi dữ liệu gửi lên thỏa mãn yêu cầu (yêu cầu theo Model) -> lưu vào DB
                context.Products.Add(product);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(product);// trở lại giao diện kèm dữ liệu vừa nhập
        }
        public ActionResult Edit(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //dựa vào id để tìm product
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public ActionResult Delete(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //dựa vào id để tìm product
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}