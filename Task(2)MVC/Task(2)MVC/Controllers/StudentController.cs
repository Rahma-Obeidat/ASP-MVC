using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_2_MVC.Models;

namespace Task_2_MVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Student()
        {

            Student s =new Student();
            List<Student> std = new List<Student>();

            std.Add(new Student {Id= 1 , Name="Rahma" , Major ="Software Engineer" , Faculity="IT"});
            std.Add(new Student { Id = 2, Name = "Rama", Major = "Finance", Faculity = "BF" });
            std.Add(new Student { Id = 3, Name = "Batool", Major = "Network and security", Faculity = "IT" });


            return View(std);
        }
    }
}