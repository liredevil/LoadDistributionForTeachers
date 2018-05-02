using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoadDistributionForTeachers.WEB.Models
{
    public class SubgroupViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int NumberOfStudents { get; set; }

        [Required]
        public int GroupNumber { get; set; }
    }
}