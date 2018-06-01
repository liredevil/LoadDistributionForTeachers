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
    public class SubgroupRepository : IRepository<Subgroup>
    {
        private ApplicationContext db;

        public SubgroupRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(Subgroup subgroup)
        {
            db.Subgroups.Add(subgroup);
        }

        public void Delete(int id)
        {
            Subgroup subgroup = db.Subgroups.Find(id);

            if (subgroup != null)
            {
                db.Subgroups.Remove(subgroup);
            }
        }

        public Subgroup Get(int id)
        {
            return db.Subgroups.Find(id);
        }

        public IEnumerable<Subgroup> GetAll()
        {
            return db.Subgroups;
        }

        public void Update(Subgroup item)
        {
            throw new NotImplementedException();
        }
    }
}
