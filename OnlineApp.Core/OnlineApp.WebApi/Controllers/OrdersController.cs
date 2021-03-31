using OnlineApp.Core.Entities;
using OnlineApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace OnlineApp.WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        private OnlineRepository db = new OnlineRepository();

        public IEnumerable<Order> GetOrders(int id)
        {
            return db.GetOrders().Where(m => m.UserId == id);//return db.getorders.where(m => m.UserId == Id)
        }

        [Route("api/AddToCart")]
        public IHttpActionResult AddToCart(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.AddToCart(order);
            return Ok(order);
        }
    }
}
