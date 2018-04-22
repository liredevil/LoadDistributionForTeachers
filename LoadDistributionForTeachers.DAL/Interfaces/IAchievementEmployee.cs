using LoadDistributionForTeachers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Interfaces
{
    public interface IAchievementEmployee<T> where T : class
    {
        void AddDate(int employeeId, int Id);
    }
}
