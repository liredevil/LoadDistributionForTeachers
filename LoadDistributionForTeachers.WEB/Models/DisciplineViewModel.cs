using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoadDistributionForTeachers.WEB.Models
{
    public class DisciplineViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
    }
}