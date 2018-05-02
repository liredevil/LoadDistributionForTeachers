using LoadDistributionForTeachers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.BLL.Interfaces
{
    public interface IContentOfThePlanService
    {
        void CreateContentOfThePlan(ContentOfThePlanDTO contentOfThePlanDTO);
        void DeleteContentOfThePlan(int id);
        IEnumerable<ContentOfThePlanDTO> GetContentOfThePlans();
        ContentOfThePlanDTO GetContentOfThePlan(int? id);
        void Dispose();
    }
}
