using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskmanagementAPI_Beta.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusDescription { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
