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
        [Display(Name = "Код группы")]
        public int GroupCode { get; set; }

        [Required]
        [Display(Name = "Имя специальности")]
        public string NameOfSpecialty { get; set; }
    }
}