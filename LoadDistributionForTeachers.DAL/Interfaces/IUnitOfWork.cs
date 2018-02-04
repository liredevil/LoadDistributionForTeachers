using LoadDistributionForTeachers.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
