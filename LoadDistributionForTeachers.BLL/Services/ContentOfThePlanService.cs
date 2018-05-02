using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDistributionForTeachers.BLL.DTO;
using LoadDistributionForTeachers.BLL.Infrastructure;
using LoadDistributionForTeachers.BLL.Interfaces;
using LoadDistributionForTeachers.DAL.Entities;
using LoadDistributionForTeachers.DAL.Interfaces;

namespace LoadDistributionForTeachers.BLL.Services
{
    public class ContentOfThePlanService : IContentOfThePlanService
    {
        IUnitOfWork Database { get; set; }

        public ContentOfThePlanService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateContentOfThePlan(ContentOfThePlanDTO contentOfThePlanDTO)
        {
            if (contentOfThePlanDTO == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            ContentOfThePlan contentOfThePlan = new ContentOfThePlan
            {
                NumberOfHoursOfLectures = contentOfThePlanDTO.NumberOfHoursOfLectures,
                NumberOfHoursOfPractice = contentOfThePlanDTO.NumberOfHoursOfPractice,
                Reporting = contentOfThePlanDTO.Reporting,
                SemesterNumber = contentOfThePlanDTO.SemesterNumber,
                AcademicPlanId = contentOfThePlanDTO.AcademicPlanId,
                DisciplineId = contentOfThePlanDTO.DisciplineId
            };

            Database.ContentOfThePlans.Create(contentOfThePlan);
            Database.Save();
        }

        public void DeleteContentOfThePlan(int id)
        {
            Database.ContentOfThePlans.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public ContentOfThePlanDTO GetContentOfThePlan(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id contentOfThePlan", "");
            }

            var contentOfThePlan = Database.ContentOfThePlans.Get(id.Value);

            if (contentOfThePlan == null)
            {
                throw new ValidationException("contentOfThePlan не найден", "");
            }

            return new ContentOfThePlanDTO
            {
                Id = contentOfThePlan.Id,
                Reporting = contentOfThePlan.Reporting,
                SemesterNumber = contentOfThePlan.SemesterNumber,
                NumberOfHoursOfLectures = contentOfThePlan.NumberOfHoursOfLectures,
                NumberOfHoursOfPractice = contentOfThePlan.NumberOfHoursOfPractice,
                DisciplineTitle = Database.Disciplines.Get(contentOfThePlan.DisciplineId).Name,
                GroupCode = Database.AcademicPlans.Get(contentOfThePlan.AcademicPlanId).GroupCode
            };
            
        }

        public IEnumerable<ContentOfThePlanDTO> GetContentOfThePlans()
        {
            IEnumerable<ContentOfThePlan> getListContentOfThePlan = Database.ContentOfThePlans.GetAll().ToList();
            List<ContentOfThePlanDTO> getListContentOfThePlanDTOs = new List<ContentOfThePlanDTO>();

            foreach (ContentOfThePlan item in getListContentOfThePlan)
            {
                getListContentOfThePlanDTOs.Add(new ContentOfThePlanDTO
                {
                    Id = item.Id,
                    NumberOfHoursOfLectures = item.NumberOfHoursOfLectures,
                    NumberOfHoursOfPractice = item.NumberOfHoursOfPractice,
                    Reporting = item.Reporting,
                    SemesterNumber = item.SemesterNumber,
                    GroupCode = Database.AcademicPlans.Get(item.AcademicPlanId).GroupCode,
                    DisciplineTitle = Database.Disciplines.Get(item.DisciplineId).Name
                });
            }

            return getListContentOfThePlanDTOs;
        }
    }
}
