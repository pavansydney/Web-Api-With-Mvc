using OnlineApp.Core.Entities;
using OnlineApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineApp.Mvc.Controllers
{
    public class OrdersController : Controller
    {
        //public ActionResult Create()
        //{
        //    OnlineClient lc = new OnlineClient();
        //    //ViewBag.listCompanies = lc.GetCompaniesIdName().Select
        //    //                          (x => new SelectListItem
        //    //                          {
        //    //                              Value = x.ID.ToString(),
        //    //                              Text = x.NAME
        //    //                          });
        //    ViewBag.listTypes = lc.GetTypeIdNameMVCModel().Select
        //                              (x => new SelectListItem
        //                              {
        //                                  Value = x.NAME,
        //                                  Text = x.NAME
        //                              });
        //    return View();
        //}
        //[HttpPost]
        public ActionResult AddToCart(int componentId)
        {
            OnlineClient lc = new OnlineClient();
            Order order = new Order();
            order.Component_Id = componentId;
            order.UserId = Convert.ToInt32(Session["userid"].ToString());
            lc.AddToCart(order);
            return RedirectToAction("Index");
            //return View();
        }
        public ActionResult Index()
        {
            OnlineClient lc = new OnlineClient();
            List<Order> lstorders = new List<Order>();
            if (Session["userid"] != null)
            {
                var userId = Convert.ToInt32(Session["userid"].ToString());
                lstorders = lc.GetAllOrders(userId).ToList();
            }
            return View(lstorders);
        }
    }
}