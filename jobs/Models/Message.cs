using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jobs.Models
{
    public class Message
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime dateTime { get; set; }
        public string Location { get; set; }
        public bool Read { get; set; }

        public BusinessProfile BusinessProfile { get; set; }
   

        public Profile Profile { get; set; }
      

        public Job Job { get; set; }
       

    }
}
