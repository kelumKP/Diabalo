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
    public class AuthersController : Controller
    {
        // GET: Authers
        public ActionResult Index()
        {
            LibraryClient lc = new LibraryClient();
            ViewBag.listAuthers = lc.GetAllAuthers();             
            return View();
        }

        // GET: Authers/Create
        public ActionResult Create()
        {
            LibraryClient lc = new LibraryClient();
            ViewBag.listEmploymentStatus = lc.GetEmplyeeStatusIdNameMVCModel().Select(x => new SelectListItem { Value = x.NAME, Text = x.NAME });
            return View("Create");
        }

        // POST: Authers/Create
        [HttpPost]
        public ActionResult Create(Auther auther)
        {
            LibraryClient lc = new LibraryClient();
            lc.CreateAuther(auther);
            return RedirectToAction("Index", "Authers");
        }

        // GET: Authers/Delete
        public ActionResult Delete(int id)
        {
            LibraryClient lc = new LibraryClient();
            lc.DeleteAuthr(id);
            return RedirectToAction("Index", "Authers");
        }

        // GET: Authers/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            LibraryClient lc = new LibraryClient();
            Auther auther = new Auther();
            ViewBag.listEmploymentStatus = lc.GetEmplyeeStatusIdNameMVCModel().Select(x => new SelectListItem { Value = x.NAME, Text = x.NAME });
            auther = lc.GetAuther(id);

            return View("Edit", auther);
        }

        // POST: Authers/Edit
        [HttpPost]
        public ActionResult Edit(Auther auther)
        {
            LibraryClient pc = new LibraryClient();
            pc.EditAuther(auther);
            return RedirectToAction("Index", "Authers");
        }
    }
}
