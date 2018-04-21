using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDistributionForTeachers.BLL.DTO;

namespace LoadDistributionForTeachers.BLL.Interfaces
{
    public interface IEmployeeService
    {
        void CreateEmployee(EmployeeDTO employeeDTO);
        void DeleteEmployee(int id);
        IEnumerable<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployee(int? id);
        void Dispose();
    }
}
