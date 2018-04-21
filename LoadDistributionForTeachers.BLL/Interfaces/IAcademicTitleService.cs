using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDistributionForTeachers.BLL.DTO;

namespace LoadDistributionForTeachers.BLL.Interfaces
{
    public interface IAcademicTitleService
    {
        void CreateAcademicTitle(AcademicTitleDTO academicTitleDTO);
        void DeleteAcademicTitle(int id);
        IEnumerable<AcademicTitleDTO> GetAcademicTitles();
        AcademicTitleDTO GetAcademicTitle(int? id);
        void Dispose();
    }
}
