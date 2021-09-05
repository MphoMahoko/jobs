using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobs.Data;
using jobs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jobs.Controllers
{
    public class InboxesController : Controller
    {
        ApplicationDbContext _context;

        public InboxesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Inboxes/Details/5
        public ActionResult Details(int id)
        {

            return View(_context.Inboxes.Where(i => i.Id ==id).Single());
        }

        // GET: Inboxes/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        public ActionResult Index()
        {

            return View(_context.Inboxes.ToList());
        }

        // POST: Inboxes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inbox inbox)
        {
            if (!ModelState.IsValid)
            {

                return View(inbox);
            }

            _context.Inboxes.Add(inbox);
            _context.SaveChanges();

            Response.Cookies.Append("content", "content");

            return RedirectToAction("Index", "Jobs");//, new { msgSent = "woza wena" });
                       
        }

        // GET: Inboxes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inboxes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return Content("sasa");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inboxes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inboxes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return Content("halala");
            }
            catch
            {
                return View();
            }
        }
    }
}