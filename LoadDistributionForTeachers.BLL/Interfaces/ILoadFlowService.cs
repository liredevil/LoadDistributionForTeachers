using LoadDistributionForTeachers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.BLL.Interfaces
{
    public interface ILoadFlowService
    {
        void CreateLoadFlow(LoadFlowDTO loadFlowDTO);
        void DeleteLoadFlow(int id);
        IEnumerable<LoadFlowDTO> GetLoadFlows();
        LoadFlowDTO GetLoadFlow(int? id);
        void Dispose();
    }
}
