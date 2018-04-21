using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoadDistributionForTeachers.WEB.Models
{
    public class AcademicTitleViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

    }
}