using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TaskmanagementAPI_Beta.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
      
        public int StatusId { get; set; }
        public Status Status { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }

}
