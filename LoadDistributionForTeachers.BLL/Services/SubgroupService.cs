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
    public class SubgroupService : ISubgroupService
    {
        IUnitOfWork Database { get; set; }

        public SubgroupService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateSubgroup(SubgroupDTO subgroupDTO)
        {
            if (subgroupDTO == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            Subgroup subgroup = new Subgroup
            {
                GroupNumber = subgroupDTO.GroupNumber,
                NumberOfStudents = subgroupDTO.NumberOfStudents
            };

            Database.Subgroups.Create(subgroup);
            Database.Save();
        }

        public void DeleteSubgroup(int id)
        {
            Database.Subgroups.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public SubgroupDTO GetSubgroup(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id Subgroup", "");
            }

            var subgroup = Database.Subgroups.Get(id.Value);

            if (subgroup == null)
            {
                throw new ValidationException("Subgroup не найден", "");
            }

            return new SubgroupDTO { Id = subgroup.Id, NumberOfStudents = subgroup.NumberOfStudents, GroupNumber = subgroup.GroupNumber };
        }

        public IEnumerable<SubgroupDTO> GetSubgroups()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Subgroup, SubgroupDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Subgroup>, List<SubgroupDTO>>(Database.Subgroups.GetAll());
        }
    }
}
