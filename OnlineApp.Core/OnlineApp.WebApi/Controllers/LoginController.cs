using OnlineApp.Core.Entities;
using OnlineApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineApp.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        private OnlineRepository db = new OnlineRepository();
        [Route("api/Login")]
        public IHttpActionResult Login(User user)
        {
            //User user = db.GetByUserId(username, password);
            var IsValid = db.LoginValidate(user);
            if (IsValid != null)
                return Ok(IsValid);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [Route("api/Register")]
        public IHttpActionResult Register(User user)
        {
            db.Registration(user);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
