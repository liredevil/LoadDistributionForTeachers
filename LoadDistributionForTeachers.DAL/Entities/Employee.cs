using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Entities
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Patronymic { get; set; }

        public ICollection<AcademicDegreeEmployee> AcademicDegreeEmployees { get; set; }

        public ICollection<AcademicTitleEmployee> AcademicTitleEmployees { get; set; }

        //public int? AcademicDegreeEmployeeId { get; set; }
        //public AcademicDegreeEmployee AcademicDegreeEmployee { get; set; }

        //public int? AcademicTitleEmployeeId { get; set; }
        //public AcademicTitleEmployee GetAcademicTitleEmployee { get; set; }

    }
}
