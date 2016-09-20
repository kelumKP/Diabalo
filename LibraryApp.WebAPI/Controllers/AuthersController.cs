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
using LibraryApp.Core.Entities;
using LibraryApp.Infrastructure;

namespace LibraryApp.WebAPI.Controllers
{
    public class AuthersController : ApiController
    {
        private LibraryRepository db = new LibraryRepository();

        // GET: api/Authers
        public IEnumerable<Auther> GetAuthers()
        {
            return db.GetAuthers();
        }

        // GET: api/Authers/5
        [ResponseType(typeof(Auther))]
        public IHttpActionResult GetAuther(int id)
        {
            Auther auther = db.FindAutherById(id);
            if (auther == null)
            {
                return NotFound();
            }

            return Ok(auther);
        }

        // PUT: api/Authers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuther(int id, Auther auther)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auther.Auth_Id)
            {
                return BadRequest();
            } 
          
            db.EditAuther(auther);               


            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Authers
        [ResponseType(typeof(Auther))]
        public IHttpActionResult PostAuther(Auther auther)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AddAuther(auther);

            return CreatedAtRoute("DefaultApi", new { id = auther.Auth_Id }, auther);
        }

        // DELETE: api/Authers/5
        [ResponseType(typeof(Auther))]
        public IHttpActionResult DeleteAuther(int id)
        {
            Auther auther = db.FindAutherById(id);
            if (auther == null)
            {
                return NotFound();
            }

            db.RemoveAuther(id);

            return Ok(auther);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: api/Authers

        [System.Web.Http.Route("api/Authers/all")] 
        public IEnumerable<Basic> GetAuthersIdName()
        {
            return db.GetAuthersIdName();
        }

        // GET: api/Authers

        [System.Web.Http.Route("api/Authers/EmploymentStatus")]
        public IEnumerable<Basic> GetEmplyeeStatusIdNameWebAPI()
        {
            return db.GetEmplyeeStatusIdName();
        }

    }
}