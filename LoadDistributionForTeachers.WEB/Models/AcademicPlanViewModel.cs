using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoadDistributionForTeachers.WEB.Models
{
    public class AcademicPlanViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int GroupCode { get; set; }

        [Required]
        public string NameOfSpecialty { get; set; }
    }
}