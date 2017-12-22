using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EndToEnd.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult home2()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult TestPage()
        {
            return View();
        }

        [Authorize]
        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Reports()
        {
            ViewBag.Message = "Reports on SmsManager";
            return View();
        }

        public ActionResult BuyCredit()
        {
            ViewBag.Message = "Buy Credit";
            return View();
        }

        public PartialViewResult Documentation()
        {
            ViewBag.Message = "This is how you can use the app for all desired actions";
            return PartialView();
        }

    }

}