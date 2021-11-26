using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace T2010A_WAD.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateNew()
        {
            return View();
        }
        public ActionResult UpdateProduct()
        {
            return View();
        }
        public ActionResult DeleteProduct()
        {
            return View();
        }
    }
}