using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Entities
{
    public class AcademicTitleEmployee
    {
        public int Id { get; set; }

        public int AcademicTitelId { get; set; }
        public AcademicTitle AcademicTitle { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
