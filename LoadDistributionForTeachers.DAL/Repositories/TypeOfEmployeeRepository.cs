using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDistributionForTeachers.DAL.EF;
using LoadDistributionForTeachers.DAL.Interfaces;
using LoadDistributionForTeachers.DAL.Entities;

namespace LoadDistributionForTeachers.DAL.Repositories
{
    public class TypeOfEmployeeRepository : IRepository<TypeOfEmployee>
    {
        private ApplicationContext db;

        public TypeOfEmployeeRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(TypeOfEmployee typeOfEmployee)
        {
            db.TypeOfEmployees.Add(typeOfEmployee);
        }

        public void Delete(int id)
        {
            TypeOfEmployee typeOfEmployee = db.TypeOfEmployees.Find(id);

            if (typeOfEmployee != null)
            {
                db.TypeOfEmployees.Remove(typeOfEmployee);
            }
        }

        public TypeOfEmployee Get(int id)
        {
            return db.TypeOfEmployees.Find(id);
        }

        public IEnumerable<TypeOfEmployee> GetAll()
        {
            return db.TypeOfEmployees;
        }
    }
}
