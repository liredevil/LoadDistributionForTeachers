using Microsoft.AspNet.Identity.EntityFramework;

namespace LoadDistributionForTeachers.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
