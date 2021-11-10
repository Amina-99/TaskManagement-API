using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskmanagementAPI_Beta.Models.Dtos
{
    public class TaskCreateDto
    {
       
        [Required]
        public string TaskName { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

    }
}
