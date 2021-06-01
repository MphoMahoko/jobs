using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using jobs.Data;
using jobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace jobs.Controllers
{
    public class ProfilesController : Controller
    {
        ApplicationDbContext _context;

        public ProfilesController(ApplicationDbContext context)
        {
            
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Applied(int id, int jobId)
        {
            var jpro = _context.JobProfiles.Include(jp=>jp.Profile).Where(jp=>jp.JobId == jobId).ToList();
            var profiles = _context.Profiles.Where(j => j.JobProfiles.All(jp => jp.JobId == 2)).ToList();

            if (jpro.Count > 0)
            {
                ViewData["applicants"] = "loads";
            }
            else {
               
                ViewData["applicants"] = "none";
            }

            var applicants = ViewData["applicants"];

            return View(jpro);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id, int jobid)
        {
           var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            /*
            string userId = "";

            try
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            catch (NullReferenceException ex)
            {
                userId = null;
            }
            */

            var user = _context.Users.Include(u=>u.Profile).SingleOrDefault(u => u.Id == userId);

            if (user.Profile == null)
            {
                ViewBag.admin = true;
                ViewBag.jobid = 0;
            }
            else
            {
                ViewBag.admin = false;
                ViewBag.jobid = jobid;
            }

            var profile = new Profile();

            

            profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId);

            
            if (profile == null)
                profile = _context.Profiles.SingleOrDefault(p => p.Id == id);

            if ( profile == null)
                return RedirectToAction("Create");

            /*
            if (userId == id.ToString())
            {
                ViewBag.admin = true;
                ViewBag.jobid = 0;
            }
            else
            {
                ViewBag.admin = false;
                ViewBag.jobid = jobid;
            }
            */
            var loggedInUser = _context.Profiles.SingleOrDefault(p => p.Id == id);

            if (loggedInUser == null)
            {
                ViewData["edit"] = "dont";
            }
            else if (loggedInUser.ApplicationUserId != userId)
            {
                ViewData["edit"] = "edit";
            }

     
            var delete = ViewData["Edit"];

            return View(profile);
        }

        public IActionResult Edit(int id)
        {
            var profile = _context.Profiles.SingleOrDefault(p => p.Id == id);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
           

            return View(profile);
        }

        [HttpPost]
        public IActionResult Edit(Profile profile, int id, IFormFile Picture)
        {
            var userprofile = _context.Profiles.SingleOrDefault(p => p.Id == id);
            var fileName = Guid.NewGuid().ToString() + Picture.FileName;

            userprofile.Email = profile.Email;
            userprofile.Facebook = profile.Facebook;
            userprofile.LookingFor = profile.LookingFor;
            userprofile.Name = profile.Name;
            userprofile.PersonalStatement = profile.PersonalStatement;
            userprofile.Phone = profile.Phone;
            userprofile.Picture = fileName;
            userprofile.ShortDescription = profile.ShortDescription;
            userprofile.SkillExpertise = profile.SkillExpertise;
            userprofile.Surname = profile.Surname;
            userprofile.Twitter = profile.Twitter;
            userprofile.Website = profile.Website;
            userprofile.WorkHistory = profile.WorkHistory;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/propics/", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                Picture.CopyToAsync(stream);
            }

            _context.SaveChanges();

            return RedirectToAction("Details", new { id = id});
        }

        [HttpPost]
        public IActionResult Create(Profile profile, IFormFile Picture)
        {
            if (!ModelState.IsValid)
            {
                return View(profile);
            }

            var fileName = Guid.NewGuid().ToString() + Picture.FileName;

            var theprofile = new Profile {
                Email = profile.Email,
                Facebook = profile.Facebook,
                LookingFor = profile.LookingFor,
                Name = profile.Name,
                PersonalStatement = profile.PersonalStatement,
                Phone = profile.Phone,
                Picture = fileName,
                ShortDescription = profile.ShortDescription,
                SkillExpertise = profile.SkillExpertise,
                Surname = profile.Surname,
                Twitter = profile.Twitter,
                Website = profile.Website,
                WorkHistory = profile.WorkHistory,
                ApplicationUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value

                
        };

           

            _context.Profiles.Add(theprofile);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/propics/", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                Picture.CopyToAsync(stream);
            }

         
             _context.SaveChanges();

            //return  RedirectToAction("Details",theprofile.Id);
            return RedirectToAction("Details", new { id = theprofile.Id });
        }
    }
}