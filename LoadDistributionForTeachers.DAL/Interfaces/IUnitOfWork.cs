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
        Task SaveAsync();
        void Save();
    }
}
