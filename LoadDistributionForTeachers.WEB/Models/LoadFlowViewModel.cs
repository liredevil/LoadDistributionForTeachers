using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoadDistributionForTeachers.WEB.Models
{
    public class LoadFlowViewModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }

        public int ContentOfThePlanId { get; set; }
        [Display(Name = "Часы лекций")]
        public int NumberOfHoursOfLectures { get; set; }
        public string Reporting { get; set; }

        public int LectureFlowId { get; set; }
        public string Title { get; set; }

        public int SubgroupId { get; set; }
        public int GroupNumber { get; set; }
        public int NumberOfStudents { get; set; }

        [Display(Name = "Часы зачет")]
        public int NumberOfHoursOfOffset { get; set; }///кол часов зачета
        [Display(Name = "Часы Экзамен")]
        public int NumberOfHoursOfExamination { get; set; }///кол часов экзамена

        public int DisciplineId { get; set; }
        [Display(Name = "Название предмета")]
        public string DisciplineName { get; set; }
    }
}