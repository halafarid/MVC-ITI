using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MVCTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTemplate.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // Any User
        [AllowAnonymous] 
        public ActionResult Index()
        {
                // Independency injection
                //var ctx = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            // Manage Roles (kol user leh eh)
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            ApplicationUser adminUser = userManager.FindByEmail("admin@gmail.com");
            ApplicationUser managerUser = userManager.FindByEmail("manager@gmail.com");
            ApplicationUser clientUser = userManager.FindByEmail("client@gmail.com");

            userManager.AddToRole(adminUser.Id, "Admin");
            userManager.AddToRole(managerUser.Id, "Manager");
            userManager.AddToRole(clientUser.Id, "Client");
            return View();
        }
        // Authenticated
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        // Authenticated
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Admin
        [Authorize(Roles = "Admin")]
        public ActionResult ForAdmin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Admin Manager
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult ForManager()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Admin Client
        [Authorize(Roles = "Admin, Client")]
        public ActionResult ForClient()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                RoleManager<IdentityRole> roleManager = 
                    new RoleManager<IdentityRole>(
                        new RoleStore<IdentityRole>(new ApplicationDbContext()));

                roleManager.Create(role);
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}