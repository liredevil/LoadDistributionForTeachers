using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDistributionForTeachers.BLL.DTO;

namespace LoadDistributionForTeachers.BLL.Interfaces
{
    public interface IAcademicDegreeService
    {
        void CreateAcademicDegree(AcademicDegreeDTO academicDegreeDTO);
        void DeleteAcademicDegree(int id);
        IEnumerable<AcademicDegreeDTO> GetAcademicDegrees();
        AcademicDegreeDTO GetAcademicDegree(int? id);
        void Dispose();
    }
}
