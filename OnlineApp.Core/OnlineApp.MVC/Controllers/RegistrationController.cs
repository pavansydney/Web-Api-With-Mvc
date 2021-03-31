using OnlineApp.Core.Entities;
using OnlineApp.Infrastructure;
using OnlineApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineApp.Mvc.Controllers
{
    public class RegistrationController : Controller
    {
        private OnlineClient db = new OnlineClient();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                bool valid = db.Registration(user);

                if (valid == true)
                {
                    TempData["msg"] = "Registration completed successfully";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.errorMessage = "User already exists !! Check username or email";
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
        }
    }
}