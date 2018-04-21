using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDistributionForTeachers.BLL.DTO;
using LoadDistributionForTeachers.BLL.Infrastructure;
using LoadDistributionForTeachers.BLL.Interfaces;
using LoadDistributionForTeachers.DAL.Interfaces;
using LoadDistributionForTeachers.DAL.Entities;
using AutoMapper;

namespace LoadDistributionForTeachers.BLL.Services
{
    public class AcademicTitleService : IAcademicTitleService
    {
        IUnitOfWork Database { get; set; }

        public AcademicTitleService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateAcademicTitle(AcademicTitleDTO academicTitleDTO)
        {
            if (academicTitleDTO == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            AcademicTitle academicTitle = new AcademicTitle
            {
                Title = academicTitleDTO.Title
            };

            Database.AcademicTitles.Create(academicTitle);
            Database.SaveAsync();
        }

        public void DeleteAcademicTitle(int id)
        {
            Database.AcademicDegrees.Delete(id);
            Database.SaveAsync();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public AcademicTitleDTO GetAcademicTitle(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id AcademicTitl", "");
            }

            var academicTitle = Database.AcademicTitles.Get(id.Value);

            if (academicTitle == null)
            {
                throw new ValidationException("AcademicTitl не найден", "");
            }

            return new AcademicTitleDTO { Id = academicTitle.Id, Title = academicTitle.Title, Employees = academicTitle.Employees };
        }

        public IEnumerable<AcademicTitleDTO> GetAcademicTitles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AcademicTitle, AcademicTitleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<AcademicTitle>, List<AcademicTitleDTO>>(Database.AcademicTitles.GetAll());
        }
    }
}
