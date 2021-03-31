using OnlineApp.Core.Entities;
using OnlineApp.Infrastructure;
using OnlineApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineApp.Mvc.Controllers
{
    public class LoginController : Controller
    {
        //private OnlineRepository repo = new OnlineRepository();
        private OnlineClient repo = new OnlineClient();
        User user = new User();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {

            if (Username != "" && Password != "")
            {
                user.Username = Username;
                user.Password = Password;
                User IsValid = repo.Login(user);
                if (IsValid != null) //user login
                {
                    Session["userid"] = IsValid.UserId;
                    Session["username"] = user.Username;
                    //FormsAuthentication.SetAuthCookie(Username, false);
                    Session["usertype"] = "user";

                    return RedirectToAction("ComponentsWithManufacturers", "ComponentsWithManufacturers");
                }
                else if (Username == "admin" && Password == "admin") //admin login
                {
                    Session["usertype"] = "admin";

                    return RedirectToAction("AdminIndex", "ComponentsWithManufacturers");
                }
                else
                {
                    ViewBag.loginError = "Invalid username or password";
                    return View();
                }
            }
            else
            {
                if (Username == "" && Password == "")
                {
                    ViewBag.ErrorMessage = "Username & Password Required !!";
                }
                else if (Username == "")
                {
                    ViewBag.ErrorMessage = "Username Required !!";
                }
                else if (Password == "")
                {
                    ViewBag.username = Username;
                    ViewBag.ErrorMessage = "Password Required !!";
                }

                return View();
            }
        }

        public ActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}