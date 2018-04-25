using LoadDistributionForTeachers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.BLL.Interfaces
{
    public interface IDisciplineService
    {
        void CreateDiscipline(DisciplineDTO disciplineDTO);
        void DeleteDiscipline(int id);
        IEnumerable<DisciplineDTO> GetDisciplines();
        DisciplineDTO GetDiscipline(int? id);
        void Dispose();
    }
}
