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
    public class LoadFlowRepository : IRepository<LoadFlow>
    {
        private ApplicationContext db;

        public LoadFlowRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(LoadFlow loadFlow)
        {
            db.LoadFlows.Add(loadFlow);
        }

        public void Delete(int id)
        {
            LoadFlow loadFlow = db.LoadFlows.Find(id);

            if (loadFlow != null)
            {
                db.LoadFlows.Remove(loadFlow);
            }
        }

        public LoadFlow Get(int id)
        {
            return db.LoadFlows.Find(id);
        }

        public IEnumerable<LoadFlow> GetAll()
        {
            return db.LoadFlows;
        }

        public void Update(LoadFlow item)
        {
            throw new NotImplementedException();
        }
    }
}
