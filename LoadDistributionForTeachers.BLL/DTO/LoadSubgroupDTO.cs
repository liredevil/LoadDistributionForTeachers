using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.BLL.DTO
{
    public class LoadSubgroupDTO
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }


        public int ContentOfThePlanId { get; set; }
        public int NumberOfHoursOfLectures { get; set; }
        public int NumberOfHoursOfPractice { get; set; }
        public string Reporting { get; set; }
        public int NumberOfHoursOfOffset { get; set; }///кол часов зачета
        public int NumberOfHoursOfExamination { get; set; }///кол часов экзамена


        public int SubgroupId { get; set; }
        public int GroupNumber { get; set; }
        public int NumberOfStudents { get; set; }
    }
}
