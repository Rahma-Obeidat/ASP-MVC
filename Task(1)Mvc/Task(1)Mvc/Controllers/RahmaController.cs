using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_1_Mvc.Controllers
{
    public class RahmaController : Controller
    {
        // GET: Rahma
        public ActionResult Index()
        {
            return View();
        }

        public string Name()
        {
            return "Rahma Aktham Obeidat";
        }

        public int Id()
        {
            return 1;
        }

        public string Description()
        {
            return "Software Engineer";
        }

        public int Age()
        {
            return 23 ;
        }


    }
}