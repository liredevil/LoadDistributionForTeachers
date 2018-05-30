using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoadDistributionForTeachers.WEB.Models
{
    public class LoadSubgroupViewModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }


        public int DisciplineId { get; set; }
        [Display(Name = "Название предмета")]
        public string DisciplineName { get; set; }


        public int ContentOfThePlanId { get; set; }
        [Display(Name = "Количество часов лекций")]
        public int NumberOfHoursOfLectures { get; set; }
        [Display(Name = "Количество часов практики")]
        public int NumberOfHoursOfPractice { get; set; }


        public int SubgroupId { get; set; }
        [Display(Name = "Номер подгруппы")]
        public int GroupNumber { get; set; }
    }
}