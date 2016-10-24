using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryApp.Core.Entities;
using LibraryApp.MVC.Models;

namespace LibraryApp.MVC.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult Index()
        {
            LibraryClient lc = new LibraryClient();
            ViewBag.listAuthors = lc.GetAllAuthors();             
            return View();
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            LibraryClient lc = new LibraryClient();
            ViewBag.listEmploymentStatus = lc.GetEmplyeeStatusIdNameMVCModel().Select(x => new SelectListItem { Value = x.NAME, Text = x.NAME });
            return View("Create");
        }

        // POST: Authors/Create
        [HttpPost]
        public ActionResult Create(Author author)
        {
            LibraryClient lc = new LibraryClient();
            lc.CreateAuthor(author);
            return RedirectToAction("Index", "Authors");
        }

        // GET: Authors/Delete
        public ActionResult Delete(int id)
        {
            LibraryClient lc = new LibraryClient();
            lc.DeleteAuthr(id);
            return RedirectToAction("Index", "Authors");
        }

        // GET: Authors/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            LibraryClient lc = new LibraryClient();
            Author author = new Author();
            ViewBag.listEmploymentStatus = lc.GetEmplyeeStatusIdNameMVCModel().Select(x => new SelectListItem { Value = x.NAME, Text = x.NAME });
            author = lc.GetAuthor(id);

            return View("Edit", author);
        }

        // POST: Authors/Edit
        [HttpPost]
        public ActionResult Edit(Author author)
        {
            LibraryClient pc = new LibraryClient();
            pc.EditAuthor(author);
            return RedirectToAction("Index", "Authors");
        }
    }
}
