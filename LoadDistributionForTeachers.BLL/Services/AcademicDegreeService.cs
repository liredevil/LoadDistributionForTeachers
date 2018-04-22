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
    public class AcademicDegreeService : IAcademicDegreeService
    {
        IUnitOfWork Database { get; set; }

        public AcademicDegreeService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateAcademicDegree(AcademicDegreeDTO academicDegreeDTO)
        {
            if(academicDegreeDTO == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            AcademicDegree academicDegree = new AcademicDegree
            {
                Title = academicDegreeDTO.Title
            };


            Database.AcademicDegrees.Create(academicDegree);
            Database.Save();
        }

        public void DeleteAcademicDegree(int id)
        {
            Database.AcademicDegrees.Delete(id);
            Database.Save();
        }

        public IEnumerable<AcademicDegreeDTO> GetAcademicDegrees()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AcademicDegree, AcademicDegreeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<AcademicDegree>, List<AcademicDegreeDTO>>(Database.AcademicDegrees.GetAll());
        }

        public AcademicDegreeDTO GetAcademicDegree(int? id)//// вроде он не нужен
        {
            if(id == null)
            {
                throw new ValidationException("Не установлено id AcademicDegree", "");
            }

            var academicDegree = Database.AcademicDegrees.Get(id.Value);

            if(academicDegree == null)
            {
                throw new ValidationException("AcademicDegree не найден", "");
            }

            return new AcademicDegreeDTO { Id = academicDegree.Id, Title = academicDegree.Title };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
