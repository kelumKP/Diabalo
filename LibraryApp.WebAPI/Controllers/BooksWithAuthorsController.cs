using LibraryApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using LibraryApp.Core.Entities;
using System.Web.Http.Description;

namespace LibraryApp.WebAPI.Controllers
{
    public class BooksWithAuthorsController : ApiController
    {
       
        private LibraryRepository db = new LibraryRepository();

        // GET: api/BooksWithAuthors
        public IEnumerable<BookWithAuthor> GetBookswithAuthors()
        {
            return db.GetBooksWithAuthors();
        }

        // GET: api/BooksWithAuthors/3

        [ResponseType(typeof(BookWithAuthor))]
        public IHttpActionResult GetBooksWithAuthorsById(int id)
        {
            BookWithAuthor bookwithauthor = db.FindBooksWithAuthorsById(id);
            if (bookwithauthor == null)
            {
                return NotFound();
            }

            return Ok(bookwithauthor);
        }

        // GET: api/BooksWithAuthors/3/Price  

        [ResponseType(typeof(decimal))]
        [System.Web.Http.Route("api/BooksWithAuthors/{id}/Price")]
        public IHttpActionResult GetBooksPriceById(int? id)
        {
            decimal bookprice = db.findBookPrice(id);

            return Ok(bookprice);
        }

        // GET: api/BooksWithAuthors/3/booktitle/Price 

        [ResponseType(typeof(decimal))]
        [System.Web.Http.Route("api/BooksWithAuthors/{id}/{name}/Price")]
        public IHttpActionResult GetBooksPriceById(int? id, string name = null)
        {
            decimal bookprice = db.findBookPrice(id,name);

            return Ok(bookprice);
        }


    }
}