using LoadDistributionForTeachers.DAL.EF;
using LoadDistributionForTeachers.DAL.Entities;
using LoadDistributionForTeachers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Repositories
{
    public class AcademicPlanRepository : IRepository<AcademicPlan>
    {
        private ApplicationContext db;

        public AcademicPlanRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(AcademicPlan academic)
        {
            db.AcademicPlans.Add(academic);
        }

        public void Delete(int id)
        {
            AcademicPlan academicPlan = db.AcademicPlans.Find(id);

            if (academicPlan != null)
            {
                db.AcademicPlans.Remove(academicPlan);
            }
        }

        public AcademicPlan Get(int id)
        {
            return db.AcademicPlans.Find(id);
        }

        public IEnumerable<AcademicPlan> GetAll()
        {
            return db.AcademicPlans;
        }
    }
}
