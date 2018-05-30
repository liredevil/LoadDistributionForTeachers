using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoadDistributionForTeachers.WEB.Models
{
    public class ContentOfThePlanViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Количество часов лекций")]
        public int NumberOfHoursOfLectures { get; set; }

        [Required]
        [Display(Name = "Количество часов практики")]
        public int NumberOfHoursOfPractice { get; set; }

        [Required]
        [Display(Name = "Номер семестра")]
        public int SemesterNumber { get; set; }

        [Required]
        [Display(Name = "Отчетность")]
        public string Reporting { get; set; }

        public int AcademicPlanId { get; set; }

        //[Required]
        [Display(Name = "Код группы")]
        public int GroupCode { get; set; }

        public int DisciplineId { get; set; }

        //[Required]
        [Display(Name = "Имя дисциплины")]
        public string DisciplineTitle { get; set; }
    }
}