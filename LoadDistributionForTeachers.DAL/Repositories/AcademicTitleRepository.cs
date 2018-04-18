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
    public class AcademicTitleRepository : IRepository<AcademicTitle>
    {
        private ApplicationContext db;

        public AcademicTitleRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(AcademicTitle academicTitle)
        {
            db.AcademicTitles.Add(academicTitle);
        }

        public void Delete(int id)
        {
            AcademicTitle academicTitle = db.AcademicTitles.Find(id);

            if(academicTitle != null)
            {
                db.AcademicTitles.Remove(academicTitle);
            }
        }

        public AcademicTitle Get(int id)
        {
            return db.AcademicTitles.Find(id);
        }

        public IEnumerable<AcademicTitle> GetAll()
        {
            return db.AcademicTitles;
        }
    }
}
