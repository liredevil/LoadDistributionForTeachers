using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Entities
{
    public class ContentOfThePlan
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int NumberOfHoursOfLectures { get; set; }

        [Required]
        public int NumberOfHoursOfPractice { get; set; }

        [Required]
        public int SemesterNumber { get; set; }

        [Required]
        public string Reporting { get; set; }

        [Required]
        public int AcademicPlanId { get; set; }
        public AcademicPlan AcademicPlan { get; set; }

        [Required]
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

    }
}
