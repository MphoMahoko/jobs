using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jobs.Models
{
    public class BusinessProfile
    {
        public int Id { get; set; }
        [Display(Name ="Company name")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Industry { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string Website { get; set; }

        

        public string ApplicationUserId { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}
