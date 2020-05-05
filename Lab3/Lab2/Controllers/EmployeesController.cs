using Lab2.Managers;
using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeesManager em = new EmployeesManager();

        public ActionResult Index()
        {
            return View(em.GetAll());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            var model = ModelState;

            if (model.IsValid)
            {
                em.Post(employee);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            Employee emp = em.GetById(id);
            if (emp == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee emp = em.GetById(id);
            if (emp == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Add", emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            Employee emp = em.Update(employee);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            em.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}