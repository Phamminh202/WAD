using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T2010A_WAD.Models;

namespace T2010A_WAD.Views
{
    public class BrandController : Controller
    {
        // GET: Brand
        private DataContext context = new DataContext();

        public ActionResult Index()
        {
            var list = context.Brands.ToList();
            return View(list);
        }
        public ActionResult CreateNew()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew(Brand brand)
        {
            if (ModelState.IsValid)
            {
                // khi dữ liệu gửi lên thỏa mãn yêu cầu (yêu cầu theo Model) -> lưu vào DB
                context.Brands.Add(brand);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(brand);// trở lại giao diện kèm dữ liệu vừa nhập
        }
        public ActionResult Edit(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //dựa vào id để tìm brand
            Brand brand = context.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                context.Entry(brand).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }
        public ActionResult Delete(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //dựa vào id để tìm brand
            Brand brand = context.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            context.Brands.Remove(brand);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}