using LoadDistributionForTeachers.BLL.Interfaces;
using LoadDistributionForTeachers.DAL.Repositories;

namespace LoadDistributionForTeachers.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
