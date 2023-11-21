using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Shorts()
        {
            return View();
        }
        public ActionResult Genre()
        {
            return View();
        }
        public ActionResult Actors()
        {
            return View();
        }
        public ActionResult Directors()
        {
            return View();
        }
        public ActionResult Rating()
        {
            return View();
        }
        public ActionResult Review()
        {
            return View();
        }

        public ActionResult Coupons()
        {
            return View();
        }
    }
}
