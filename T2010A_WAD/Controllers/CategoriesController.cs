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
        public ActionResult Index()
        {
            ViewData["PageTitles"] = "Categories Page";
            ViewBag.PageTitle = "Demo title";
            //var category = new Category() { Id = 1, CategoryName = "Fashion" };
            //ViewBag.Category = category;
            var list = new List<Category>();
            list.Add(new Category() { Id = 1, CategoryName = "Fashion" });
            list.Add(new Category() { Id = 3, CategoryName = "Fa" });
            list.Add(new Category() { Id = 4, CategoryName = "Sa" });
            return View(list);
        }
        public ActionResult CreateNew()
        {
            return View();
        }
        public ActionResult UpdateCategory()
        {
            return View();
        }
        public ActionResult DeleteCategory()
        {
            return View();
        }
    }
}