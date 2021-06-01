using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jobs.Models
{
    public class JobProfile
    {
        public int JobId { get; set; }
        public Job Job { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public DateTime date { get; set; }
    }
}
