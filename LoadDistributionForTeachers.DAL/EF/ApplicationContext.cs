using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using LoadDistributionForTeachers.DAL.Entities;

namespace LoadDistributionForTeachers.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<AcademicTitle> AcademicTitles { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }

        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new DropCreateDatabaseIfModelChanges<ApplicationContext>());
        }

        public ApplicationContext(string conectionString)
            : base(conectionString) { }


        //public ApplicationContext()
        //    : base("DefaultConnection", throwIfV1Schema: false)
        //{

        //}

        //public static ApplicationContext Create()
        //{
        //    return new ApplicationContext();
        //}
    }
}
