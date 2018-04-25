using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDistributionForTeachers.DAL.Entities;
using LoadDistributionForTeachers.DAL.Interfaces;
using LoadDistributionForTeachers.BLL.Interfaces;
using LoadDistributionForTeachers.BLL.DTO;
using LoadDistributionForTeachers.BLL.Infrastructure;
using AutoMapper;

namespace LoadDistributionForTeachers.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        IUnitOfWork Database { get; set; }

        public EmployeeService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateEmployee(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            
            Employee employee = new Employee
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                Patronymic = employeeDTO.Patronymic,
                AcademicDegreeId = employeeDTO.AcademicDegreeDTOId,
                AcademicTitleId = employeeDTO.AcademicTitleDTOId
            };
            

            Database.Employees.Create(employee);
            Database.Save();
        }

        public void DeleteEmployee(int id)
        {
            Database.Employees.Delete(id);
            Database.Save();
        }

        public EmployeeDTO GetEmployee(int? id)///переделать для редактирования
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id Employee", "");
            }

            var employee = Database.Employees.Get(id.Value);

            if (employee == null)
            {
                throw new ValidationException("Employee не найден", "");
            }

            return new EmployeeDTO { Id = employee.Id, FirstName = employee.FirstName, LastName = employee.LastName, Patronymic = employee.Patronymic };
        }

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            IEnumerable<Employee> getListEmployees = Database.Employees.GetAll().ToList();
            List<EmployeeDTO> getListemployeeDTOs = new List<EmployeeDTO>();

            foreach(Employee item in getListEmployees)
            {
                getListemployeeDTOs.Add(new EmployeeDTO
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Patronymic = item.Patronymic,
                    AcademicDegreeTitle = Database.AcademicDegrees.Get(item.AcademicDegreeId).Title,
                    AcademicTitleName = Database.AcademicTitles.Get(item.AcademicTitleId).Title
                });
            }

            return getListemployeeDTOs;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
