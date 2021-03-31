using OnlineApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Mvc.Filter;

namespace OnlineApp.Mvc.Controllers
{
    public class ComponentsWithManufacturersController : Controller
    {

        public ActionResult ComponentsWithManufacturers()
        {
            OnlineClient bwu = new OnlineClient();
            ViewBag.listComponentsWithManufacturers = bwu.GetComponentsWithManufacturers();
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
        //[AllowAnonymous]
        public ActionResult AdminIndex()
        {
            OnlineClient bwu = new OnlineClient();
            ViewBag.listComponentsWithManufacturers = bwu.GetComponentsWithManufacturers();
            return View();
        }

    }
}