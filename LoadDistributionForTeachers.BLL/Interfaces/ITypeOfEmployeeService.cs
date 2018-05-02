using LoadDistributionForTeachers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.BLL.Interfaces
{
    public interface ITypeOfEmployeeService
    {
        void CreateTypeOfEmployee(TypeOfEmployeeDTO typeOfEmployeeDTO);
        void DeleteTypeOfEmployee(int id);
        IEnumerable<TypeOfEmployeeDTO> GetTypeOfEmployees();
        TypeOfEmployeeDTO GetTypeOfEmployee(int? id);
        void Dispose();
    }
}
