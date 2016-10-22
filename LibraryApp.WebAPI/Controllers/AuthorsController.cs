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
    public class AuthorsController : ApiController
    {
        private LibraryRepository db = new LibraryRepository();

        // GET: api/Authors
        public IEnumerable<Author> GetAuthors()
        {
            return db.GetAuthors();
        }

        // GET: api/Authors/5
        [ResponseType(typeof(Author))]
        public IHttpActionResult GetAuthor(int id)
        {
            Author author = db.FindAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // PUT: api/Authors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuthor(int id, Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.Auth_Id)
            {
                return BadRequest();
            } 
          
            db.EditAuthor(author);               


            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Authors
        [ResponseType(typeof(Author))]
        public IHttpActionResult PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AddAuthor(author);

            return CreatedAtRoute("DefaultApi", new { id = author.Auth_Id }, author);
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Author))]
        public IHttpActionResult DeleteAuthor(int id)
        {
            Author author = db.FindAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            db.RemoveAuthor(id);

            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: api/Authors

        [System.Web.Http.Route("api/Authors/all")] 
        public IEnumerable<Basic> GetAuthorsIdName()
        {
            return db.GetAuthorsIdName();
        }

        // GET: api/Authors

        [System.Web.Http.Route("api/Authors/EmploymentStatus")]
        public IEnumerable<Basic> GetEmplyeeStatusIdNameWebAPI()
        {
            return db.GetEmplyeeStatusIdName();
        }

    }
}