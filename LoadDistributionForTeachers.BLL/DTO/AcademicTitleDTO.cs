using LoadDistributionForTeachers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.BLL.DTO
{
    public class AcademicTitleDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
