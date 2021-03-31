using OnlineApp.Mvc.Models;
using OnlineApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineApp.Mvc.Controllers
{
    public class UsersController : Controller
    {
       public ActionResult Details(int id = 1)
        {
            OnlineClient lc = new OnlineClient();
            User user = lc.GetUser(id);
            return View();
       }

        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
            OnlineClient lc = new OnlineClient();
            User user = new User();
            user = lc.GetUser(id);
            //ViewBag.listManufacturers = lc.GetUsersIdName().Select
            //                                           (x => new SelectListItem
            //                                           {
            //                                               Value = x.ID.ToString(),
            //                                               Text = x.NAME
            //                                           });
            return View("Edit", user);
        }
        // POST: Products/Edit
        [HttpPost]
        public ActionResult Edit(User user)
        {
            OnlineClient pc = new OnlineClient();
            pc.EditUser(user);
            return RedirectToAction("ComponentsWithManufacturers", "ComponentsWithManufacturers");
        }
    }
}