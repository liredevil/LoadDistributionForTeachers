using LoadDistributionForTeachers.DAL.Identity;
using System;
using System.Threading.Tasks;
using LoadDistributionForTeachers.DAL.Entities;

namespace LoadDistributionForTeachers.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IRepository<Employee> Employees { get; }
        IRepository<AcademicDegree> AcademicDegrees { get; }
        IRepository<AcademicTitle> AcademicTitles { get; }
        IRepository<Discipline> Disciplines { get; }
        IRepository<AcademicPlan> AcademicPlans { get; }
        IRepository<Subgroup> Subgroups { get; }
        IRepository<ContentOfThePlan> ContentOfThePlans { get; }
        IRepository<LoadSubgroup> LoadSubgroups { get; }
        IRepository<LectureFlow> LectureFlows { get; }
        IRepository<LoadFlow> LoadFlows { get; }
        Task SaveAsync();
        void Save();
    }
}
