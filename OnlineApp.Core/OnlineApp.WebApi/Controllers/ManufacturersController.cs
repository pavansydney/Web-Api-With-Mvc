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
    public class ManufacturersController : ApiController
    {
        //private OnlineContext db = new OnlineContext();
        private OnlineRepository db = new OnlineRepository();

        // GET: api/Manufacturers
        public IEnumerable<Manufacturer> GetManufacturers()
        {
            return db.GetManufacturers();
        }

        // GET: api/Manufacturers/5
        [ResponseType(typeof(Manufacturer))]
        public IHttpActionResult GetManufacturer(int id)
        {
            Manufacturer manufacturer = db.FindManufacturerById(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(manufacturer);
        }

        // PUT: api/Manufacturers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutManufacturer(int id, Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manufacturer.Manufacturer_Id)
            {
                return BadRequest();
            }
            db.EditManufacturer(manufacturer);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Manufacturers
        [ResponseType(typeof(Manufacturer))]
        public IHttpActionResult PostManufacturer(Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.AddManufacturer(manufacturer);

            return CreatedAtRoute("DefaultApi", new { id = manufacturer.Manufacturer_Id }, manufacturer);
        }

        // DELETE: api/Manufacturers/5
        [ResponseType(typeof(Manufacturer))]
        public IHttpActionResult DeleteManufacturer(int id)
        {
            Manufacturer manufacturer = db.FindManufacturerById(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            db.RemoveManufacturer(id);

            return Ok(manufacturer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
        [Route("api/Manufacturers/All")]
        public IEnumerable<Basic> GetManufacturersIdName()
        {
            return db.GetManufacturersIdName();
        }
        //GET: api/Companies
        // http://localhost:2134/api/Companies/AuthorizationStatus URI
        // Here we are sharing Authorization status Dropdown as web service URL
        [Route("api/Manufacturers/AuthorizationStatus")]
        public IEnumerable<Basic> GetAuthorizationStatusIdNameWebAPI()
        {
            return db.GetAuthorizationStatusIdName();
        }
    }
}