/* DESIGNER: Claudinei Pereira de Sousa (100647340)
   EXERCISE: Assignment 02
   TASK: Doonut Website - ASP.NET MVC Project */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _100647340PereiraDeSousaA2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Menu()
        {
            ViewBag.Message = "Our Products.";

            return View();
        }
       

    }
}