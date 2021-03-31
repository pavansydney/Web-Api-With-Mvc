using OnlineApp.Core.Entities;
using OnlineApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Mvc.Filter;

namespace OnlineApp.Mvc.Controllers
{

    public class ComponentsController : Controller
    {
        // GET: Products/Create
        public ActionResult Create()
        {
            OnlineClient lc = new OnlineClient();
            ViewBag.listManufacturers = lc.GetManufacturersIdName().Select
                                      (x => new SelectListItem
                                      {
                                          Value = x.ID.ToString(),
                                          Text = x.NAME
                                      });
            ViewBag.listTypes = lc.GetTypeIdNameMVCModel().Select
                                      (x => new SelectListItem
                                      {
                                          Value = x.NAME,
                                          Text = x.NAME
                                      });
            return View();
        }



        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Components components)
        {
            OnlineClient lc = new OnlineClient();
            lc.CreateComponent(components);
            return RedirectToAction("AdminIndex", "ComponentsWithManufacturers");
        }

        // GET: Products/Delete
        public ActionResult Delete(int id)
        {
            OnlineClient lc = new OnlineClient();
            lc.DeleteComponent(id);
            return RedirectToAction("AdminIndex", "ComponentsWithManufacturers");
        }
        // GET: Products/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            OnlineClient lc = new OnlineClient();
            Components components = new Components();
            components = lc.GetComponent(id);
            ViewBag.listManufacturers = lc.GetManufacturersIdName().Select
                                                       (x => new SelectListItem
                                                       {
                                                           Value = x.ID.ToString(),
                                                           Text = x.NAME
                                                       });
            ViewBag.listEditions = lc.GetTypeIdNameMVCModel().Select
                                                      (x => new SelectListItem
                                                      {
                                                          Value = x.NAME,
                                                          Text = x.NAME
                                                      });
            return View("Edit", components);
        }
        // POST: Products/Edit
        [HttpPost]
        public ActionResult Edit(Components components)
        {
            OnlineClient pc = new OnlineClient();
            pc.EditComponent(components);
            return RedirectToAction("AdminIndex", "ComponentsWithManufacturers");
        }
        public ActionResult Details(int id)
        {
            OnlineClient lc = new OnlineClient();
            //Components components = new Components();
            Components components = lc.GetComponent(id);
            //ViewBag.listManufacturers = lc.GetManufacturersIdName().Select
            //                                           (x => new SelectListItem
            //                                           {
            //                                               Value = x.ID.ToString(),
            //                                               Text = x.NAME
            //                                           });
            //ViewBag.listEditions = lc.GetTypeIdNameMVCModel().Select
            //                                          (x => new SelectListItem
            //                                          {
            //                                              Value = x.NAME,
            //                                              Text = x.NAME
            //                                          });
            //lc.
            return RedirectToAction("Index", "Orders");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}