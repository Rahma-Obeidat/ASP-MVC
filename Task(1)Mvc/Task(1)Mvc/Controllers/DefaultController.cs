using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Task_1_Mvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        //public string Index()
        //{
        //    return ("<a href='https://localhost:44355/Default/Download'><img src='img/j.png'/></a>");


        //}


        //public FileResult Download()
        //{
        //    var path = Server.MapPath("~/img/j.png");
        //    return File(path, "png", "j.png");

        //}

        public ActionResult Image()
        {
            return Content("<a href='/img/j.png' download><img src='..\\img\\j.PNG' width='400'><a>");

        }



        public ActionResult GetImage()
        {
            string path = Server.MapPath("~/img/j.png");
            byte[] imageByteData = System.IO.File.ReadAllBytes(path);
            return File(imageByteData, "image/png" , "~/img/j.png");
           

        }
       

        public string About()
        {

            return "A controller is an individual who has responsibility for all accounting-related activities, including high-level accounting, managerial accounting, and finance activities, within a company.";

        }

        public string Contact()
        {

            return "Duties of Financial Controllers Contact Us";
        }


    }
}