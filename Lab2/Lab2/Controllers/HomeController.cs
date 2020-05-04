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
        public object EmplyeeManager { get; private set; }

        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Form()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Form(Employee employee)
        {
            var model = ModelState;

            if (model.IsValid)
            {
                ViewBag.Name = employee.Name;
                EmployeeManager em = new EmployeeManager();
                em.Post(employee);
                return View("Welcome", employee);
                
            }
            return View();
        }
    }
}