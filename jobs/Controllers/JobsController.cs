using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobs.Data;
using jobs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace jobs.Controllers
{
    public class JobsController : Controller
    {
        //private readonly UserManager<ApplicationUser> _userManager;

        ApplicationDbContext _context;

        

        public JobsController(ApplicationDbContext context)
        {
           
            _context = context;
        }

        [Authorize]
        public IActionResult Apply(int id)
        {

           

            var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
         


            var profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == UserId);

            if (profile == null)
            {
                return RedirectToAction("Create", "Profiles");
            }
            else
            {
                var appliedJob = new JobProfile
                {
                    JobId = id,
                    ProfileId = profile.Id,
                    date = DateTime.Now
                };

                _context.JobProfiles.Add(appliedJob);
                _context.SaveChanges();
            }

            var job = _context.Jobs.Include(j=>j.businessProfile).SingleOrDefault(j => j.Id == id);

            ViewBag.Applied = "true";
            ViewBag.application = true;

            return View("Details", job);
        }

        public IActionResult PostedJobs()
        {
            var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var businessProfile = _context.BusinessProfiles.SingleOrDefault(bp => bp.ApplicationUserId == UserId);

            if (businessProfile == null)
                return RedirectToAction("Create", "BusinessProfile");

            var jobs = _context.Jobs.Include(j => j.JobProfiles).Include(j => j.businessProfile).Where(j => j.businessProfile == businessProfile).ToList();

            if (jobs == null)
                ViewBag.jobs = false;
            else
                ViewBag.jobs = true;

            return View(jobs);
        }

        public IActionResult Index()
        {
            return View(_context.Jobs.Include(j => j.businessProfile).Where(j => j.Available == true).ToList());
        }

        //[Authorize(Roles ="Administrator")]
        public IActionResult Create()
        {
            
            //asdf
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            
                
           // return Content(User.Identity.Name);



            
            var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var businessProfile = _context.BusinessProfiles.SingleOrDefault(bp => bp.ApplicationUserId == UserId);

            if (businessProfile == null)
                return RedirectToAction("Create", "BusinessProfile");

         


            return View();
            
        }

        public IActionResult Applied()
        {
            var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == UserId);



            var jobprofiles = _context.JobProfiles.Include(jp => jp.Job.businessProfile).Where(jp => jp.Profile == profile);

            ViewData["numberOfJobs"] = jobprofiles.Count();

            if (profile == null)
                return RedirectToAction("Create", "Profiles");

            if (jobprofiles == null)
                ViewBag.jobs = false;
            else
                ViewBag.jobs = true;

            return View("AppliedJobs", jobprofiles);
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {

            if (!ModelState.IsValid)
            {

                return View(job);
            }
            else
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var businessProfile = _context.BusinessProfiles.SingleOrDefault(bp => bp.ApplicationUserId == UserId);

                

                job.PostDate = DateTime.Now;

                switch (job.Type)
                {
                    case "Full time":
                        job.badge = "badge-warning";
                        break;

                    case "Part time":
                        job.badge = "badge-success";
                        break;

                    case "Freelance":
                        job.badge = "badge-primary";
                        break;

                    case "Internship":
                        job.badge = "badge-info";
                        break;

                    case "Temporary":
                        job.badge = "badge-dark";
                        break;
                }

                job.businessProfile = businessProfile;
                _context.Jobs.Add(job);
                _context.SaveChanges();

                return RedirectToAction("PostedJobs");
            }
        }

        public IActionResult Details(int id)
        {
            var job = _context.Jobs.Include(j=>j.businessProfile).SingleOrDefault(j => j.Id == id);
            string userId = "";

            try
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            catch (NullReferenceException ex)
            {
                userId = null;
            }

            if (userId == null)
            {
                ViewBag.Applied = "false";
                return View(job);
            }

            var user = _context.Users.SingleOrDefault(u => u.Id == userId);

            var businessProfile = _context.BusinessProfiles.SingleOrDefault(bp => bp.ApplicationUserId == userId);

            


            if (user.Position == "Employer" && job.businessProfile.ApplicationUserId == userId)
            {
                ViewBag.Applied = "owner";
            }
            else if (businessProfile != null)
            {
                ViewBag.Applied = "admin";
            }
            else if (user.Position == "Employer" && businessProfile == null)
            {
                ViewBag.Applied = "admin";
            }
            else
            {
                var profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId);

                if (profile != null)
                {
                    var appliedJob = _context.JobProfiles.Where(jp => jp.ProfileId == profile.Id && jp.JobId == id).ToList();

                    if (appliedJob.Count == 0)
                    {
                        ViewBag.Applied = "false";
                    }
                    else
                    {
                        ViewBag.Applied = "true";
                    }
                }
                else
                {
                    ViewBag.Applied = "false";
                }

            }

            return View(job);
        }

        public IActionResult Edit(int id)
        {
            return View(_context.Jobs.SingleOrDefault(j => j.Id == id));
        }

        public IActionResult Search()
        {
            var province = Request.Form["Province"];
            var jobtype = Request.Form["JobType"];
            var title = Request.Form["Title"];

            
            List<Job> jobs = new List<Job>();

            if (title != String.Empty && province == string.Empty && jobtype == string.Empty)
            {
                jobs = _context.Jobs.Include(j => j.businessProfile).Where(j => j.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else if (title != String.Empty && jobtype == string.Empty && province != string.Empty)
            {
                jobs = _context.Jobs.Include(j => j.businessProfile).Where(j => j.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && j.Location == province).ToList();
            }
            else if (title != String.Empty && jobtype != string.Empty && province == string.Empty)
            {
                jobs = _context.Jobs.Include(j => j.businessProfile).Where(j => j.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && j.Type == jobtype).ToList();
            }
            else if (title != String.Empty && jobtype != string.Empty && province != string.Empty)
            {
                jobs = _context.Jobs.Include(j => j.businessProfile).Where(j => j.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && j.Type == jobtype && j.Location == province).ToList();
            }
            else if (title == String.Empty && jobtype != string.Empty && province != string.Empty)
            {
                jobs = _context.Jobs.Include(j => j.businessProfile).Where(j=>j.Type == jobtype && j.Location == province).ToList();
            }
            else if (title == String.Empty && jobtype != string.Empty && province == string.Empty)
            {
                jobs = _context.Jobs.Include(j => j.businessProfile).Where(j => j.Type == jobtype).ToList();
            }
            else if (title == String.Empty && jobtype == string.Empty && province != string.Empty)
            {
                jobs = _context.Jobs.Include(j => j.businessProfile).Where(j => j.Location == province).ToList();
            }
            else
            {
                jobs = _context.Jobs.Include(j => j.businessProfile).Where(j =>  j.Available == true).ToList();
            }

    

            return View(jobs);


    
        }

        public IActionResult Delete(int id)
        {
            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);
            job.Available = false;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Job job)
        {
            if (!ModelState.IsValid)
            {

                return View(job);
            }
            else
            {
                var thejob = _context.Jobs.SingleOrDefault(j => j.Id == job.Id);

                switch (thejob.Type)
                {
                    case "Full time":
                        thejob.badge = "badge-warning";
                        break;

                    case "Part time":
                        thejob.badge = "badge-success";
                        break;

                    case "Freelance":
                        thejob.badge = "badge-primary";
                        break;

                    case "Internship":
                        thejob.badge = "badge-info";
                        break;

                    case "Temporary":
                        thejob.badge = "badge-dark";
                        break;
                }

                var badget = thejob.badge;
                thejob.Benefits = job.Benefits;
                thejob.Description = job.Description;
                thejob.EducationExperience = job.EducationExperience;
                thejob.ExperienceYears = job.ExperienceYears;
                thejob.ExpiryDate = job.ExpiryDate;
                thejob.Location = job.Location;
                thejob.Title = job.Title;
                thejob.SalaryRange = job.SalaryRange;
                thejob.Type = job.Type;

                _context.SaveChanges();


                return RedirectToAction("Index");
            }
        }
    }
}