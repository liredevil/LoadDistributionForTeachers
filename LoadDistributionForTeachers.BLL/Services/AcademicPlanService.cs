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
    public class AcademicPlanService : IAcademicPlanService
    {
        IUnitOfWork Database { get; set; }

        public AcademicPlanService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateAcademicPlan(AcademicPlanDTO academicPlanDTO)
        {
            if (academicPlanDTO == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            AcademicPlan academicPlan = new AcademicPlan
            {
                GroupCode = academicPlanDTO.GroupCode,
                NameOfSpecialty = academicPlanDTO.NameOfSpecialty
            };


            Database.AcademicPlans.Create(academicPlan);
            Database.Save();
        }

        public void DeleteAcademicPlan(int id)
        {
            Database.AcademicPlans.Delete(id);
            Database.Save();
        }

        public IEnumerable<AcademicPlanDTO> GetAcademicPlans()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AcademicPlan, AcademicPlanDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<AcademicPlan>, List<AcademicPlanDTO>>(Database.AcademicPlans.GetAll());
        }

        public AcademicPlanDTO GetAcademicPlan(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id AcademicPlan", "");
            }

            var academicPlan = Database.AcademicPlans.Get(id.Value);

            if (academicPlan == null)
            {
                throw new ValidationException("AcademicDegree не найден", "");
            }

            return new AcademicPlanDTO { Id = academicPlan.Id, NameOfSpecialty = academicPlan.NameOfSpecialty, GroupCode = academicPlan.GroupCode };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
