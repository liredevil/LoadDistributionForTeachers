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
    public class LoadFlowService : ILoadFlowService
    {
        IUnitOfWork Database { get; set; }

        public LoadFlowService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateLoadFlow(LoadFlowDTO loadFlowDTO)
        {
            if (loadFlowDTO == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            LoadFlow loadFlow = new LoadFlow
            {
                ContentOfThePlanId = loadFlowDTO.ContentOfThePlanId,
                EmployeeId = loadFlowDTO.EmployeeId,
                LectureFlowId = loadFlowDTO.LectureFlowId
            };

            Database.LoadFlows.Create(loadFlow);
            Database.Save();
        }

        public void DeleteLoadFlow(int id)
        {
            Database.LoadFlows.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public LoadFlowDTO GetLoadFlow(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoadFlowDTO> GetLoadFlows()
        {
            IEnumerable<LoadFlow> getListLoad = Database.LoadFlows.GetAll().ToList();
            List<LoadFlowDTO> getListLoadDTOs = new List<LoadFlowDTO>();

            foreach (LoadFlow item in getListLoad)
            {
                ContentOfThePlan contentOfThePlan = Database.ContentOfThePlans.Get(item.ContentOfThePlanId);
                int numberOfStudent = 0;
                List<Subgroup> getList = Database.Subgroups.GetAll().Where(c => c.LectureFlowId == item.LectureFlowId).ToList();
                for(int i = 0; i< getList.Count();i++)
                {
                    numberOfStudent += getList[i].NumberOfStudents;
                }
                //var a = getList.Where(c => c.LectureFlowId == item.LectureFlowId);
                int hourСredit = 0;
                int houreExam = 0;
                if (contentOfThePlan.Reporting == "Зачет")
                {
                    //contentOfThePlan.NumberOfHoursOfPractice += 2;
                    hourСredit += 2;
                }
                else
                {
                    //contentOfThePlan.NumberOfHoursOfPractice += (20 * subgroup.NumberOfStudents)/60 ;
                    houreExam += (20 * numberOfStudent) / 60;
                }

                getListLoadDTOs.Add(new LoadFlowDTO
                {
                    Id = item.Id,
                    Name = Database.Employees.Get(item.EmployeeId).LastName + " " + Database.Employees.Get(item.EmployeeId).Patronymic,
                    Title = Database.LectureFlows.Get(item.LectureFlowId).Title,
                    //NumberOfStudents = Database.Subgroups.Get(item.SubgroupId).NumberOfStudents,
                    NumberOfHoursOfLectures = Database.ContentOfThePlans.Get(item.ContentOfThePlanId).NumberOfHoursOfLectures,
                    //NumberOfHoursOfPractice = contentOfThePlan.NumberOfHoursOfPractice, /*Database.ContentOfThePlans.Get(item.ContentOfThePlanId).NumberOfHoursOfPractice,*/
                    NumberOfHoursOfOffset = hourСredit,
                    NumberOfHoursOfExamination = houreExam,
                    Reporting = Database.ContentOfThePlans.Get(item.ContentOfThePlanId).Reporting,

                    DisciplineId = Database.ContentOfThePlans.Get(item.ContentOfThePlanId).DisciplineId,
                    DisciplineName = Database.Disciplines.Get(Database.ContentOfThePlans.Get(item.ContentOfThePlanId).DisciplineId).Name,
                    //DisciplineName = Database.ContentOfThePlans.Get(item.ContentOfThePlanId)
                });
            }

            return getListLoadDTOs;
        }
    }
}
