using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDistributionForTeachers.DAL.Interfaces;
using LoadDistributionForTeachers.DAL.EF;
using LoadDistributionForTeachers.DAL.Entities;

namespace LoadDistributionForTeachers.DAL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private ApplicationContext db;

        public EmployeeRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
        }

        public void Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee != null) 
            {
                db.Employees.Remove(employee);
            }
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees;
        }
    }
}
