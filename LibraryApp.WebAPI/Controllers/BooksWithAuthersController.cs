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
    public class BooksWithAuthersController : ApiController
    {
       
        private LibraryRepository db = new LibraryRepository();

        // GET: api/BooksWithAuthers
        public IEnumerable<BookWithAuther> GetBookswithAuthers()
        {
            return db.GetBooksWithAuthers();
        }

        // GET: api/BooksWithAuthers/3

        [ResponseType(typeof(BookWithAuther))]
        public IHttpActionResult GetBooksWithAuthersById(int id)
        {
            BookWithAuther bookwithauther = db.FindBooksWithAuthersById(id);
            if (bookwithauther == null)
            {
                return NotFound();
            }

            return Ok(bookwithauther);
        }

        // GET: api/BooksWithAuthers/3/Price  

        [ResponseType(typeof(decimal))]
        [System.Web.Http.Route("api/BooksWithAuthers/{id}/Price")]
        public IHttpActionResult GetBooksPriceById(int? id)
        {
            decimal bookprice = db.findBookPrice(id);

            return Ok(bookprice);
        }

        // GET: api/BooksWithAuthers/3/booktitle/Price 

        [ResponseType(typeof(decimal))]
        [System.Web.Http.Route("api/BooksWithAuthers/{id}/{name}/Price")]
        public IHttpActionResult GetBooksPriceById(int? id, string name = null)
        {
            decimal bookprice = db.findBookPrice(id,name);

            return Ok(bookprice);
        }


    }
}