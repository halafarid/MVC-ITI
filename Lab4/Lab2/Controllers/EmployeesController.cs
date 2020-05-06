using Lab2.Managers;
using Lab2.Models;
using Lab2.ViewModels;
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
            EmployeeViewModel vm = new EmployeeViewModel
            {
                Employees = em.GetAll(),
                Employee = new Employee()
            };
            return View(vm);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            ViewBag.Action = "Add";
            var model = ModelState;

            if (model.IsValid)
            {
                em.Post(employee);
                return RedirectToAction(nameof(Index));
            }

            return View("Add");
        }

        [HttpPost]
        public ActionResult AddAjax(Employee employee)
        {
            var model = ModelState;

            if (model.IsValid)
            {
                em.Post(employee);
            }
            return PartialView("partials/_ColPartial", employee);
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
            ViewBag.Action = "Edit";
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
            ViewBag.Action = "Edit";
            Employee emp = em.Update(employee);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            em.Delete(id);
            return Json(true);
        }
    }
}