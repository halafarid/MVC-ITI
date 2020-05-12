using Lab2.Managers;
using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class HomeController : Controller
    {
        //[HandleError]
        public ViewResult Index()
        {
            //throw new Exception("custom error");
            return View();
        }

        public ViewResult About()
        {
            return View();
        }
    }
}