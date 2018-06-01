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
    public class LoadSubgroupService : ILoadSubgroupService
    {
        IUnitOfWork Database { get; set; }

        public LoadSubgroupService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateLoad(LoadSubgroupDTO loadDTO)
        {
            if (loadDTO == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            LoadSubgroup loadSubgroup = new LoadSubgroup
            {
                ContentOfThePlanId = loadDTO.ContentOfThePlanId,
                EmployeeId = loadDTO.EmployeeId,
                SubgroupId = loadDTO.SubgroupId
            };

            //ContentOfThePlan contentOfThePlan = Database.ContentOfThePlans.Get(loadDTO.ContentOfThePlanId);
            //if(contentOfThePlan.Reporting == "Зачет")
            //{
            //    contentOfThePlan.NumberOfHoursOfPractice += 2;
            //}
            
            Database.LoadSubgroups.Create(loadSubgroup);
            //Database.ContentOfThePlans.Update(contentOfThePlan);
            Database.Save();
        }

        public void DeleteLoad(int id)
        {
            Database.LoadSubgroups.Delete(id);
            Database.Save();
        }

        public IEnumerable<LoadSubgroupDTO> GetLoads()
        {
            IEnumerable<LoadSubgroup> getListLoad = Database.LoadSubgroups.GetAll().ToList();
            List<LoadSubgroupDTO> getListLoadDTOs = new List<LoadSubgroupDTO>();

            foreach (LoadSubgroup item in getListLoad)
            {
                ContentOfThePlan contentOfThePlan = Database.ContentOfThePlans.Get(item.ContentOfThePlanId);
                Subgroup subgroup = Database.Subgroups.Get(item.SubgroupId);
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
                    houreExam += (20 * subgroup.NumberOfStudents) / 60;
                }

                getListLoadDTOs.Add(new LoadSubgroupDTO
                {
                    Id = item.Id,
                    Name = Database.Employees.Get(item.EmployeeId).LastName + " " + Database.Employees.Get(item.EmployeeId).Patronymic,
                    GroupNumber = Database.Subgroups.Get(item.SubgroupId).GroupNumber,
                    //NumberOfStudents = Database.Subgroups.Get(item.SubgroupId).NumberOfStudents,
                    //NumberOfHoursOfLectures = Database.ContentOfThePlans.Get(item.ContentOfThePlanId).NumberOfHoursOfLectures,
                    NumberOfHoursOfPractice = contentOfThePlan.NumberOfHoursOfPractice, /*Database.ContentOfThePlans.Get(item.ContentOfThePlanId).NumberOfHoursOfPractice,*/
                    NumberOfHoursOfOffset = hourСredit,
                    NumberOfHoursOfExamination = houreExam,
                    //Reporting = Database.ContentOfThePlans.Get(item.ContentOfThePlanId).Reporting,

                    DisciplineId = Database.ContentOfThePlans.Get(item.ContentOfThePlanId).DisciplineId,
                    DisciplineName = Database.Disciplines.Get(Database.ContentOfThePlans.Get(item.ContentOfThePlanId).DisciplineId).Name,
                    //DisciplineName = Database.ContentOfThePlans.Get(item.ContentOfThePlanId)
                });
            }

            return getListLoadDTOs;
        }

        public LoadSubgroupDTO GetLoad(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id Load", "");
            }

            var load = Database.LoadSubgroups.Get(id.Value);

            if (load == null)
            {
                throw new ValidationException("Load не найден", "");
            }

            return new LoadSubgroupDTO
            {
                Id = load.Id,
                Name = Database.Employees.Get(load.EmployeeId).LastName + Database.Employees.Get(load.EmployeeId).Patronymic,
                GroupNumber = Database.Subgroups.Get(load.SubgroupId).GroupNumber,
                //NumberOfHoursOfLectures = Database.ContentOfThePlans.Get(load.ContentOfThePlanId).NumberOfHoursOfLectures,
                NumberOfHoursOfPractice = Database.ContentOfThePlans.Get(load.ContentOfThePlanId).NumberOfHoursOfPractice,
                Reporting = Database.ContentOfThePlans.Get(load.ContentOfThePlanId).Reporting,

                DisciplineId = Database.ContentOfThePlans.Get(load.ContentOfThePlanId).DisciplineId,
                DisciplineName = Database.ContentOfThePlans.Get(load.ContentOfThePlanId).Discipline.Name
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
