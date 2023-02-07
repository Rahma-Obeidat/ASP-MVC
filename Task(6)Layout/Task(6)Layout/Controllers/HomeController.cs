using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_6_Layout.Models;

namespace Task_6_Layout.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Customer c= new Customer();
            ViewBag.massege = c;
            return View(c);
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            Customer c = new Customer();
            ViewBag.massege = c;
            return View(c);
          
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}