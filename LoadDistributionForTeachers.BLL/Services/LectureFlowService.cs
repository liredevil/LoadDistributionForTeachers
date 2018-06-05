using AutoMapper;
using LoadDistributionForTeachers.BLL.DTO;
using LoadDistributionForTeachers.BLL.Infrastructure;
using LoadDistributionForTeachers.BLL.Interfaces;
using LoadDistributionForTeachers.DAL.Entities;
using LoadDistributionForTeachers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.BLL.Services
{
    public class LectureFlowService : ILectureFlowService
    {
        IUnitOfWork Database { get; set; }

        public LectureFlowService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateLectureFlow(LectureFlowDTO lectureFlowDTO)
        {
            if (lectureFlowDTO == null)
            {
                throw new ValidationException("Введите данные", "");
            }

            LectureFlow lectureFlow = new LectureFlow
            {
                Title = lectureFlowDTO.Title,
            };

            Database.LectureFlows.Create(lectureFlow);
            Database.Save();
        }

        public void DeleteLectureFlow(int id)
        {
            Database.LectureFlows.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public LectureFlowDTO GetLectureFlow(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LectureFlowDTO> GetLectureFlows()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LectureFlow, LectureFlowDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<LectureFlow>, List<LectureFlowDTO>>(Database.LectureFlows.GetAll());
        }
    }
}
