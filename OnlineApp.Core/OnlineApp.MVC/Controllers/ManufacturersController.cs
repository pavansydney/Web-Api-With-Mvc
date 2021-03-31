using OnlineApp.Core.Entities;
using OnlineApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineApp.Mvc.Controllers
{
    public class ManufacturersController : Controller
    {
        public ActionResult Index()
        {
            OnlineClient lc = new OnlineClient();
            ViewBag.listManufacturers = lc.GetAllManufacturers();
            return View();
        }

        public ActionResult Create()
        {
            OnlineClient lc = new OnlineClient();
            ViewBag.listAuthorizationStatus = lc.GetAuthorizationStatusIdNameMVCModel().Select
            (x => new SelectListItem
            {
                Value = x.NAME,
                Text = x.NAME
            });
               return View("Create");
        }

        // POST: Companies/Create
        [HttpPost]
        public ActionResult Create(Manufacturer manufacturer)
        {
            OnlineClient lc = new OnlineClient();
            lc.CreateManufacturer(manufacturer);
            return RedirectToAction("Index", "Manufacturers");
        }

        public ActionResult Delete(int id)
        {
            OnlineClient lc = new OnlineClient();
            lc.DeleteManufacturer(id);
            return RedirectToAction("Index", "Manufacturers");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            OnlineClient lc = new OnlineClient();
            Manufacturer manufacturer = new Manufacturer();
            ViewBag.listAuthorizationStatus = lc.GetAuthorizationStatusIdNameMVCModel().Select
            (x => new SelectListItem
            {
                Value = x.NAME,
                Text = x.NAME
            });
            manufacturer = lc.GetManufacturer(id);

            return View("Edit", manufacturer);
        }

        [HttpPost]
        public ActionResult Edit(Manufacturer manufacturer)
        {
            OnlineClient pc = new OnlineClient();
            pc.EditMAnufacturer(manufacturer);
            return RedirectToAction("Index", "Manufacturers");
        }
    }
}