using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_3_DataAnn.Models;

namespace Task_3_DataAnn.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult DataAnnotation()
        {
            return View();
        }

        public ActionResult SaveData(Employee e)
        {
            if (ModelState.IsValid)
            {
                return View(e);
            }
            else
            {

                return View("DataAnnotation");

            }
        }


    }
}