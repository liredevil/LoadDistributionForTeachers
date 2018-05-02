using LoadDistributionForTeachers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoadDistributionForTeachers.BLL.Interfaces
{
    public interface ISubgroupService
    {
        void CreateSubgroup(SubgroupDTO subgroupDTO);
        void DeleteSubgroup(int id);
        IEnumerable<SubgroupDTO> GetSubgroups();
        SubgroupDTO GetSubgroup(int? id);
        void Dispose();
    }
}
