using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDistributionForTeachers.DAL.EF;
using LoadDistributionForTeachers.DAL.Entities;
using LoadDistributionForTeachers.DAL.Interfaces;

namespace LoadDistributionForTeachers.DAL.Repositories
{
    public class DisciplineRepository : IRepository<Discipline>
    {
        private ApplicationContext db;

        public DisciplineRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(Discipline discipline)
        {
            db.Disciplines.Add(discipline);
        }

        public void Delete(int id)
        {
            Discipline discipline = db.Disciplines.Find(id);

            if (discipline != null)
            {
                db.Disciplines.Remove(discipline);
            }
        }

        public Discipline Get(int id)
        {
            return db.Disciplines.Find(id);
        }

        public IEnumerable<Discipline> GetAll()
        {
            return db.Disciplines;
        }
    }
}
