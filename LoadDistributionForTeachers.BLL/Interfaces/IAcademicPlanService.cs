using LoadDistributionForTeachers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.BLL.Interfaces
{
    public interface IAcademicPlanService
    {
        void CreateAcademicPlan(AcademicPlanDTO academicPlanDTO);
        void DeleteAcademicPlan(int id);
        IEnumerable<AcademicPlanDTO> GetAcademicPlans();
        AcademicPlanDTO GetAcademicPlan(int? id);
        void Dispose();
    }
}
