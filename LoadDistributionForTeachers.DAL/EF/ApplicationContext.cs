using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using LoadDistributionForTeachers.DAL.Entities;

namespace LoadDistributionForTeachers.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
