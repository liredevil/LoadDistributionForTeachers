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
        [Display(Name = "Количество студентов")]
        public int NumberOfStudents { get; set; }

        [Required]
        [Display(Name = "Номер группы")]
        public int GroupNumber { get; set; }
    }
}