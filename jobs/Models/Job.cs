using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jobs.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime PostDate { get; set; }

        
        [Display(Name = "Expiry date")]
        [Required(ErrorMessage = "Expiry date is required")]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public string Location { get; set; }
        [Display(Name ="Years of experience")]
        public string ExperienceYears { get; set; }
        [Display(Name = "Salary range")]
        public string SalaryRange { get; set; }

        
        public string Responsibilities { get; set; }

        [Display(Name = "Education and Qualifications")]
        public string EducationExperience { get; set; }
        public string Benefits { get; set; }
        public string badge { get; set; }
        public bool Available { get; set; }

        public ICollection<JobProfile> JobProfiles { get; set; }

        public BusinessProfile businessProfile { get; set; }
    }
}
