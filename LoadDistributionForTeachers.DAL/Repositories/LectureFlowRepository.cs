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
    public class LectureFlowRepository : IRepository<LectureFlow>
    {
        private ApplicationContext db;

        public LectureFlowRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(LectureFlow lectureFlow)
        {
            db.LectureFlows.Add(lectureFlow);
        }

        public void Delete(int id)
        {
            LectureFlow lectureFlow = db.LectureFlows.Find(id);

            if (lectureFlow != null)
            {
                db.LectureFlows.Remove(lectureFlow);
            }
        }

        public LectureFlow Get(int id)
        {
            return db.LectureFlows.Find(id);
        }

        public IEnumerable<LectureFlow> GetAll()
        {
            return db.LectureFlows;
        }

        public void Update(LectureFlow item)
        {
            throw new NotImplementedException();
        }
    }
}
