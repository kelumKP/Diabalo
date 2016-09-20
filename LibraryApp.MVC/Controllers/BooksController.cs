using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryApp.Core.Entities;
using LibraryApp.Infrastructure;
using LibraryApp.MVC.Models;

namespace LibraryApp.MVC.Controllers
{
    public class BooksController : Controller
    {


        // GET: Books/Create
        public ActionResult Create()  
        {
            LibraryClient lc = new LibraryClient();

            // NonStrongly Type  
            //------------------------------------------
            //Method 1
            //ViewBag.listAuthers = new SelectList(lc.GetAuthersIdName(), "ID", "NAME");
            //Method 2
            ViewBag.listAuthers = lc.GetAuthersIdName().Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.NAME });

            //------------------------------------------


            // Strongly Type
            //------------------------------------------
            /*
            Book model = new Book
            {
                //Method 1
                Authers = new SelectList(lc.GetAuthersIdName(), "ID", "NAME");
                //Method 2
                Authers = lc.GetAuthersIdName().Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.NAME })
            }; 

            return View(model);
            //------------------------------------------ 
            */
            ViewBag.listEditions = lc.GetEditionIdNameMVCModel().Select(x => new SelectListItem { Value = x.NAME, Text = x.NAME });

            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            LibraryClient lc = new LibraryClient();
            lc.CreateBook(book);
            return RedirectToAction("BookswithAuthers", "BookWithAuther");
        }

        // GET: Books/Delete
        public ActionResult Delete(int id)
        {
            LibraryClient lc = new LibraryClient();
            lc.DeleteBook(id);
            return RedirectToAction("BookswithAuthers", "BookWithAuther");
        }

        // GET: Books/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            LibraryClient lc = new LibraryClient();
            Book book = new Book();
            book = lc.GetBook(id);
            ViewBag.listAuthers = lc.GetAuthersIdName().Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.NAME });
            ViewBag.listEditions = lc.GetEditionIdNameMVCModel().Select(x => new SelectListItem { Value = x.NAME, Text = x.NAME });
            return View("Edit", book);
        }

        // POST: Books/Edit
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            LibraryClient pc = new LibraryClient();
            pc.EditBook(book);
            return RedirectToAction("BookswithAuthers", "BookWithAuther");
        }
    }
}
