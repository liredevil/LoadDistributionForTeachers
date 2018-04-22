using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDistributionForTeachers.DAL.Interfaces;
using LoadDistributionForTeachers.DAL.Entities;
using LoadDistributionForTeachers.DAL.EF;

namespace LoadDistributionForTeachers.DAL.Repositories
{
    public class AcademicDegreeEmployeeRepository : IAchievementEmployee<AcademicDegreeEmployee>
    {
        private ApplicationContext db;

        public AcademicDegreeEmployeeRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void AddDate(int employeeId, int AcademicDegreeId)
        {
            AcademicDegreeEmployee academicDegreeEmployee = new AcademicDegreeEmployee
            {
                EmployeeId = employeeId,
                AcademicDegreeId = AcademicDegreeId
            };

            db.AcademicDegreeEmployees.Add(academicDegreeEmployee);
        }
    }
}
