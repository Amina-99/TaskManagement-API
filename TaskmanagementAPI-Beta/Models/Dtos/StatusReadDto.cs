using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskmanagementAPI_Beta.Models.Dtos
{
    public class StatusReadDto
    {
        [Required]
        public int StatusId { get; set; }
        [Required]
        public string StatusDescription { get; set; }
    }
}
