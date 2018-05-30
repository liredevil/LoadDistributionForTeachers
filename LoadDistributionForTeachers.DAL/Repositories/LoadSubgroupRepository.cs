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
    public class LoadSubgroupRepository : IRepository<LoadSubgroup>
    {
        private ApplicationContext db;

        public LoadSubgroupRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(LoadSubgroup loadSubgroup)
        {
            db.LoadSubgroups.Add(loadSubgroup);
        }

        public void Delete(int id)
        {
            LoadSubgroup loadSubgroup = db.LoadSubgroups.Find(id);

            if (loadSubgroup != null) 
            {
                db.LoadSubgroups.Remove(loadSubgroup);
            }
        }

        public LoadSubgroup Get(int id)
        {
            return db.LoadSubgroups.Find(id);
        }

        public IEnumerable<LoadSubgroup> GetAll()
        {
            return db.LoadSubgroups;
        }
    }
}
