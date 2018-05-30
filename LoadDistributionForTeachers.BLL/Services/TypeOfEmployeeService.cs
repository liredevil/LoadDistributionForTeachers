using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LoadDistributionForTeachers.BLL.DTO;
using LoadDistributionForTeachers.BLL.Infrastructure;
using LoadDistributionForTeachers.BLL.Interfaces;
using LoadDistributionForTeachers.DAL.Entities;
using LoadDistributionForTeachers.DAL.Interfaces;

namespace LoadDistributionForTeachers.BLL.Services
{
    /*public class TypeOfEmployeeService : ITypeOfEmployeeService
    {
        IUnitOfWork Database { get; set; }

        public TypeOfEmployeeService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateTypeOfEmployee(TypeOfEmployeeDTO typeOfEmployeeDTO)
        {
            if (typeOfEmployeeDTO == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            TypeOfEmployee typeOfEmployee = new TypeOfEmployee
            {
                Title = typeOfEmployeeDTO.Title
            };

            Database.TypeOfEmployees.Create(typeOfEmployee);
            Database.Save();
        }

        public void DeleteTypeOfEmployee(int id)
        {
            Database.TypeOfEmployees.Delete(id);
            Database.Save();
        }

        public IEnumerable<TypeOfEmployeeDTO> GetTypeOfEmployees()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeOfEmployee, TypeOfEmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TypeOfEmployee>, List<TypeOfEmployeeDTO>>(Database.TypeOfEmployees.GetAll());
        }

        public TypeOfEmployeeDTO GetTypeOfEmployee(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id typeOfEmployee", "");
            }

            var typeOfEmployee = Database.TypeOfEmployees.Get(id.Value);

            if (typeOfEmployee == null)
            {
                throw new ValidationException("typeOfEmployee не найден", "");
            }

            return new TypeOfEmployeeDTO { Id = typeOfEmployee.Id,Title = typeOfEmployee.Title };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }*/
}
