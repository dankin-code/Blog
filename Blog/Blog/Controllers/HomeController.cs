using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        [RequireHttps]
        public ActionResult Index()
        {
            return View();
        }

        [RequireHttps]
        public ActionResult About()
        {
            ViewBag.Message = "About Me";

            return View();
        }

        [RequireHttps]
        public ActionResult Blog()
        {
            ViewBag.Message = "My Blog.";

            return View();
        }
    }
}