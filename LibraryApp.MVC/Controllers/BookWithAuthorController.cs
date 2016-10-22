using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryApp.Core.Entities;
using LibraryApp.MVC.Models;

namespace LibraryApp.MVC.Controllers
{
    public class BookWithAuthorController : Controller
    {
        // GET: BooksWithAuthors
        public ActionResult BookswithAuthors()
        {
            LibraryClient bwu = new LibraryClient();
            ViewBag.listBookswithAuthors = bwu.GetAllBookWithAuthors();
             return View();
        }
    }
}