using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RsvpForm(string name, string email, string phone, string attendance)
        {
            if (name != null && email != null)
            {
                ViewBag.Name = name;
                return View("Welcome");
            }
            return View();
        }
    }
}