using LoadDistributionForTeachers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.BLL.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public int AcademicDegreeDTOId { get; set; }
        public AcademicDegreeDTO AcademicDegreeDTO { get; set; }

        public int AcademicTitleDTOId { get; set; }
        public AcademicTitleDTO AcademicTitleDTO { get; set; }
    }
}
