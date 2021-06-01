using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jobs.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Position { get; set; }

        public Profile Profile { get; set; }
    }
}
