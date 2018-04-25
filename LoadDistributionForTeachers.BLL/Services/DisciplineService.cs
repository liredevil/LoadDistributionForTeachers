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
    public class DisciplineService : IDisciplineService
    {
        IUnitOfWork Database { get; set; }

        public DisciplineService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateDiscipline(DisciplineDTO disciplineDTO)
        {
            if (disciplineDTO == null)
            {
                throw new ValidationException("Введите данные", "");
            }

            Discipline discipline = new Discipline
            {
                Name = disciplineDTO.Name
            };

            Database.Disciplines.Create(discipline);
            Database.Save();
        }

        public void DeleteDiscipline(int id)
        {
            Database.Disciplines.Delete(id);
            Database.Save();
        }

        public DisciplineDTO GetDiscipline(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DisciplineDTO> GetDisciplines()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Discipline, DisciplineDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Discipline>, List<DisciplineDTO>>(Database.Disciplines.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
