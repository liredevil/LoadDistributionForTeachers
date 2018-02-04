using LoadDistributionForTeachers.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace LoadDistributionForTeachers.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
