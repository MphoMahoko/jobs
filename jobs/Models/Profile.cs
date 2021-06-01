using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jobs.Models
{
    public class Profile
    {
        public int Id { get; set; }

        [Required]
        public string Picture { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string ShortDescription { get; set; }
        public string PersonalStatement { get; set; }
        public string LookingFor { get; set; }
        public string SkillExpertise { get; set; }
        public string WorkHistory { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<JobProfile> JobProfiles { get; set; }
    }
}
