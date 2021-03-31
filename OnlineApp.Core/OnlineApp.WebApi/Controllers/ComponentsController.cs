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
    public class ComponentsController : ApiController
    {
        //private OnlineContext db = new OnlineContext();
        private OnlineRepository db = new OnlineRepository();

        // GET: api/Components
        public IEnumerable<Components> GetComponents()
        {
            return db.GetComponents();
        }

        // GET: api/Components/5
        [ResponseType(typeof(Components))]
        public IHttpActionResult GetComponents(int id)
        {
            Components components = db.FindComponenttById(id);
            if (components == null)
            {
                return NotFound();
            }

            return Ok(components);
        }

        // PUT: api/Components/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComponents(int id, Components components)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != components.Components_Id)
            {
                return BadRequest();
            }
            db.EditComponent(components);

            return StatusCode(HttpStatusCode.NoContent);
        }
           

        // POST: api/Components
        [ResponseType(typeof(Components))]
        public IHttpActionResult PostComponents(Components components)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AddComponent(components);

            return CreatedAtRoute("DefaultApi", new { id = components.Components_Id }, components);
        }

        // DELETE: api/Components/5
        [ResponseType(typeof(Components))]
        public IHttpActionResult DeleteComponents(int id)
        {
            Components components = db.FindComponenttById(id);
            if (components == null)
            {
                return NotFound();
            }

            db.RemoveComponent(id);

            return Ok(components);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Route("api/Components/Types")]
        public IEnumerable<Basic> GetTypeIdNameWebAPI()
        {
            // Calling the Reopsitory project GetEditionIdName method
            return db.GetTypeIdName();
        }
    }
}