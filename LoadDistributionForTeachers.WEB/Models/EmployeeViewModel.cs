using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoadDistributionForTeachers.WEB.Models
{
    public class EmployeeViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Patronymic { get; set; }


        public int AcademicDegreeIdViewModel { get; set; }
        public AcademicDegreeViewModel AcademicDegreeViewModel { get; set; }

        public int AcademicTitleIdViewModel { get; set; }
        public AcademicTitleViewModel AcademicTitleViewModel { get; set; }
    }
}