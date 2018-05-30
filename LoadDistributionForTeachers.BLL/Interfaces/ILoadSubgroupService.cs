using LoadDistributionForTeachers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.BLL.Interfaces
{
    public interface ILoadSubgroupService
    {
        void CreateLoad(LoadSubgroupDTO loadDTO);
        void DeleteLoad(int id);
        IEnumerable<LoadSubgroupDTO> GetLoads();
        LoadSubgroupDTO GetLoad(int? id);
        void Dispose();
    }
}
