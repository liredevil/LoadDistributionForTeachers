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
    public class AcademicTitleEmployeeRepository : IAchievementEmployee<AcademicTitleEmployee>
    {
        private ApplicationContext db;

        public AcademicTitleEmployeeRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void AddDate(AcademicTitleEmployee item, int EmployeeId)
        {
            throw new NotImplementedException();
        }

        public void AddDate(Employee item, int EmployeeId)
        {
            throw new NotImplementedException();
        }

        public void AddDate(int employeeId, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
