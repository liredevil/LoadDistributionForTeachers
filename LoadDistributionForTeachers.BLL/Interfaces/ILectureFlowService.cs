using LoadDistributionForTeachers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.BLL.Interfaces
{
    public interface ILectureFlowService
    {
        void CreateLectureFlow(LectureFlowDTO lectureFlowDTO);
        void DeleteLectureFlow(int id);
        IEnumerable<LectureFlowDTO> GetLectureFlows();
        LectureFlowDTO GetLectureFlow(int? id);
        void Dispose();
    }
}
