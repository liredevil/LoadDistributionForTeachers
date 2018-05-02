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
    public class ContentOfThePlanRepository : IRepository<ContentOfThePlan>
    {
        private ApplicationContext db;

        public ContentOfThePlanRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(ContentOfThePlan contentOfThePlan)
        {
            db.ContentOfThePlans.Add(contentOfThePlan);
        }

        public void Delete(int id)
        {
            ContentOfThePlan contentOfThePlan = db.ContentOfThePlans.Find(id);

            if (contentOfThePlan != null)
            {
                db.ContentOfThePlans.Remove(contentOfThePlan);
            }
        }

        public ContentOfThePlan Get(int id)
        {
            return db.ContentOfThePlans.Find(id);
        }

        public IEnumerable<ContentOfThePlan> GetAll()
        {
            return db.ContentOfThePlans;
        }
    }
}
