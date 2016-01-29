using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["useremail"] == null && Session["useremail"] == "")
            {
                return RedirectToAction("../Account/Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["useremail"] = "";
            Session["role"] = "";
            Session["fname"] = "";
            return RedirectToAction("Login", "Account");
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
    }
}