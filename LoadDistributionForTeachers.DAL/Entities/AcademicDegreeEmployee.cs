

namespace LoadDistributionForTeachers.DAL.Entities
{
    public class AcademicDegreeEmployee
    {
        public int Id { get; set; }

        public int AcademicDegreeId { get; set; }
        public AcademicDegree AcademicDegree { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }


    }
}
