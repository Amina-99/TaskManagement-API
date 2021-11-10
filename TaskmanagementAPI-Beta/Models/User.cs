
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TaskmanagementAPI_Beta.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
