using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using LoadDistributionForTeachers.DAL.Entities;

namespace LoadDistributionForTeachers.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString)
            : base(conectionString) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<AcademicTitle> AcademicTitles { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
