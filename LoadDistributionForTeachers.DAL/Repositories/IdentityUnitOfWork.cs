using LoadDistributionForTeachers.DAL.EF;
using LoadDistributionForTeachers.DAL.Entities;
using LoadDistributionForTeachers.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using LoadDistributionForTeachers.DAL.Identity;

namespace LoadDistributionForTeachers.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;
        private AcademicDegreeRepository academicDegreeRepository;
        private AcademicTitleRepository academicTitleRepository;
        private EmployeeRepository employeeRepository;
        private DisciplineRepository disciplineRepository;
        private AcademicPlanRepository academicPlanRepository;
        private SubgroupRepository subgroupRepository;
        //private TypeOfEmployeeRepository typeOfEmployeeRepository;
        private ContentOfThePlanRepository contentOfThePlanRepository;
        private LoadSubgroupRepository loadSubgroupRepository;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public IRepository<AcademicDegree> AcademicDegrees
        {
            get
            {
                if (academicDegreeRepository == null)
                    academicDegreeRepository = new AcademicDegreeRepository(db);
                return academicDegreeRepository;
            }
        }

        public IRepository<AcademicTitle> AcademicTitles
        {
            get
            {
                if (academicTitleRepository == null)
                    academicTitleRepository = new AcademicTitleRepository(db);
                return academicTitleRepository;
            }
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }

        public IRepository<Discipline> Disciplines
        {
            get
            {
                if (disciplineRepository == null)
                {
                    disciplineRepository = new DisciplineRepository(db);
                }

                return disciplineRepository;
            }
        }

        public IRepository<AcademicPlan> AcademicPlans
        {
            get
            {
                if (academicPlanRepository == null)
                {
                    academicPlanRepository = new AcademicPlanRepository(db);
                }

                return academicPlanRepository;
            }
        }

        public IRepository<Subgroup> Subgroups
        {
            get
            {
                if (subgroupRepository == null)
                {
                    subgroupRepository = new SubgroupRepository(db);
                }

                return subgroupRepository;
            }
        }

        //public IRepository<TypeOfEmployee> TypeOfEmployees
        //{
        //    get
        //    {
        //        if (typeOfEmployeeRepository == null)
        //        {
        //            typeOfEmployeeRepository = new TypeOfEmployeeRepository(db);
        //        }

        //        return typeOfEmployeeRepository;
        //    }
        //}

        public IRepository<ContentOfThePlan> ContentOfThePlans
        {
            get
            {
                if(contentOfThePlanRepository == null)
                {
                    contentOfThePlanRepository = new ContentOfThePlanRepository(db);
                }

                return contentOfThePlanRepository;
            }
        }

        public IRepository<LoadSubgroup> LoadSubgroups
        {
            get
            {
                if (loadSubgroupRepository == null)
                {
                    loadSubgroupRepository = new LoadSubgroupRepository(db);
                }

                return loadSubgroupRepository;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
