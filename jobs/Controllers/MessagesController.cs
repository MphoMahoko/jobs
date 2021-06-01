using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using jobs.Data;
using jobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jobs.Controllers
{
    public class MessagesController : Controller
    {
        ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == UserId);

            var messages = _context.Messages.Include(m => m.Job).Include(m=>m.BusinessProfile).Where(m => m.Profile.Id == profile.Id).OrderBy(m=>m.Read).ToList();
           

            return View(messages);
        }

        public IActionResult Details(int id)
        {
            var message = _context.Messages.Include(m=>m.Profile).Include(m=>m.Job).Include(m=>m.BusinessProfile).SingleOrDefault(m => m.Id == id);
            message.Read = true;
            _context.SaveChanges();
            return View(message);
        }


        [HttpPost]
        public IActionResult Send(int id, int jobid)
        {

            var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var businessProfile = _context.BusinessProfiles.SingleOrDefault(bp => bp.ApplicationUserId == UserId);
            var businessProfileId = businessProfile.Id;

            var job = _context.Jobs.Single(j => j.Id == jobid);

            var profileId = Int32.Parse(Request.Form["profileId"]);
            var profile = _context.Profiles.SingleOrDefault(p => p.Id == profileId);

            string dateTime = Request.Form["Date"] + " " + Request.Form["Time"] + ":00";

            DateTime parseDateTime = DateTime.Parse(dateTime);

            var message = new Message
            {
                Location = Request.Form["Location"],
                Job = job,
                dateTime = parseDateTime,
                BusinessProfile = businessProfile,
                Profile = profile, 
                CreatedOn = DateTime.Now,
                Read = false
            };

            _context.Messages.Add(message);
            _context.SaveChanges();

            return Content("Did");


        }
    }
}