using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryApp.Core.Entities;
using LibraryApp.MVC.Models;

namespace LibraryApp.MVC.Controllers
{
    public class BookWithAutherController : Controller
    {
        // GET: BooksWithAuthers
        public ActionResult BookswithAuthers()
        {
            LibraryClient bwu = new LibraryClient();
            ViewBag.listBookswithAuthers = bwu.GetAllBookWithAuthers();
             return View();
        }
    }
}