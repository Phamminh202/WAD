using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T2010A_WAD.Models;

namespace T2010A_WAD.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        private DataContext context = new DataContext();
        public ActionResult Index()
        {
            
            ViewData["PageTitles"] = "Categories Page";
            ViewBag.PageTitle = "Demo title";
            //var category = new Category() { Id = 1, CategoryName = "Fashion" };
            //ViewBag.Category = category;
            //var list = new List<Category>();
            //list.Add(new Category() { Id = 1, CategoryName = "Fashion" });

            var list = context.Categories.ToList();
            return View(list);
        }
        public ActionResult CreateNew()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew(Category category)
        {
            if (ModelState.IsValid)
            {
                // khi dữ liệu gửi lên thỏa mãn yêu cầu (yêu cầu theo Model) -> lưu vào DB
                context.Categories.Add(category);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(category);// trở lại giao diện kèm dữ liệu vừa nhập
        }
        public ActionResult Edit(int ? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //dựa vào id để tìm category
            Category category = context.Categories.Find(id);
            if(category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public ActionResult Delete(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //dựa vào id để tìm category
            Category category = context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}