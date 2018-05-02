using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoadDistributionForTeachers.WEB.Models
{
    public class ContentOfThePlanViewModel
    {
        public int Id { get; set; }

        public int NumberOfHoursOfLectures { get; set; }

        public int NumberOfHoursOfPractice { get; set; }

        public int SemesterNumber { get; set; }

        public string Reporting { get; set; }

        public int AcademicPlanId { get; set; }
        public int GroupCode { get; set; }

        public int DisciplineId { get; set; }
        public string DisciplineTitle { get; set; }
    }
}