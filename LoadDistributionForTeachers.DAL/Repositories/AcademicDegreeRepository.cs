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
    public class AcademicDegreeRepository : IRepository<AcademicDegree>
    {
        private ApplicationContext db;

        public AcademicDegreeRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(AcademicDegree academicDegree)
        {
            db.AcademicDegrees.Add(academicDegree);
        }

        public void Delete(int id)
        {
            AcademicDegree academicDegree = db.AcademicDegrees.Find(id);

            if (academicDegree != null)
            {
                db.AcademicDegrees.Remove(academicDegree);
            }
        }

        public AcademicDegree Get(int id)
        {
            return db.AcademicDegrees.Find(id);
        }

        public IEnumerable<AcademicDegree> GetAll()
        {
            return db.AcademicDegrees;
        }

        public void Update(AcademicDegree item)
        {
            throw new NotImplementedException();
        }
    }
}
