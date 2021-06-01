using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using jobs.Data;
using jobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace jobs.Controllers
{
    public class BusinessProfileController : Controller
    {
        ApplicationDbContext _context;

        public BusinessProfileController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Single()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profile = _context.BusinessProfiles.Where(b=>b.ApplicationUserId == userId).Single();
            return View(profile);
        }

        public IActionResult Edit(int id)
        {
            var profile = _context.BusinessProfiles.SingleOrDefault(b => b.Id == id);
            return View(profile);
        }

        [HttpPost]
        public IActionResult Edit(BusinessProfile profile, int id)
        {
            var userprofile = _context.BusinessProfiles.SingleOrDefault(p => p.Id == id);

            userprofile.Industry = profile.Industry;
            userprofile.Name = profile.Name;
            userprofile.Phone = profile.Phone;
            userprofile.Province = profile.Province;
            userprofile.Website = profile.Website;
            userprofile.ApplicationUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            _context.SaveChanges();

            return RedirectToAction("Single", new {id = id });
        }

        public IActionResult Create()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusinessProfile businessProfile)
        {
            if (!ModelState.IsValid)
            {
                return View(businessProfile);
            }
            else
            {
                var applicationUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                businessProfile.ApplicationUserId = applicationUserId;

                _context.BusinessProfiles.Add(businessProfile);
                _context.SaveChanges();

                return RedirectToAction("Create", "Jobs");

                
            }


            
        }
    }
}