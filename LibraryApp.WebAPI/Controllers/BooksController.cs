using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using System.Net.Http;

using System.Web.Http.Description;
using LibraryApp.Core.Entities;
using LibraryApp.Infrastructure;
using System.Web.Http;
using System.Net;

namespace LibraryApp.WebAPI.Controllers
{
    public class BooksController : ApiController
    {
        private LibraryRepository db = new LibraryRepository();

        //// GET: api/Books
        // Get all the books 
        public IEnumerable<Book> GetBooks()
        {
            return db.GetBooks();
        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            Book book = db.FindBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }


        //// PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Book_Id)
            {
                return BadRequest();
            }

            db.EditBook(book);   

            return StatusCode(HttpStatusCode.NoContent);
        }

        //// POST: api/Books/
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AddBook(book);

            return CreatedAtRoute("DefaultApi", new { id = book.Book_Id }, book);
        }

        //// DELETE: api/Books//5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.FindBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            db.RemoveBook(id); 

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }

        [System.Web.Http.Route("api/Books/Editions")]
        public IEnumerable<Basic> GetEditionIdNameWebAPI()
        {
            return db.GetEditionIdName();
        }

    }
}