using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineApp.Core.Entities;
using OnlineApp.Infrastructure;

namespace OnlineApp.WebApi.Controllers
{
    public class ComponentsWithManufacturersController : ApiController
    {
        //private OnlineContext db = new OnlineContext();
        private OnlineRepository db = new OnlineRepository();

        // GET: api/ComponentsWithManufacturers
        public IEnumerable<ComponentsWithManufacturer> GetComponentsWithManufacturers()
        {
            return db.GetComponentsWithManufacturers();
        }

        // GET: api/ComponentsWithManufacturers/5
        [ResponseType(typeof(ComponentsWithManufacturer))]
        public IHttpActionResult GetComponentsWithManufacturerById(int id)
        {
            ComponentsWithManufacturer componentsWithManufacturer = db.FindComponentsWithManufacturerById(id);
            if (componentsWithManufacturer == null)
            {
                return NotFound();
            }

            return Ok(componentsWithManufacturer);
        }
        //GET: api/ProductWithCompanies/3/Price
        [ResponseType(typeof(decimal))]
        [System.Web.Http.Route("api/ComponentsWithManufacturers/{id}/Price")]
        public IHttpActionResult GetComponentsPriceById(int? id)
        {
            decimal productPrice = db.findComponentsPrice(id);
            return Ok(productPrice);
        }



        //GET: api/ProductWithCompanies/3/ProductName/Price
        [ResponseType(typeof(decimal))]
        [System.Web.Http.Route("api/ComponentsWithManufacturers/{id}/{name}/Price")]
        public IHttpActionResult GetComponentsPriceById(int? id, string name = null)
        {
            decimal productPrice = db.findComponentsPrice(id, name);
            return Ok(productPrice);
        }
    }
}