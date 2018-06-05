using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using LoadDistributionForTeachers.BLL.Services;
using LoadDistributionForTeachers.BLL.Interfaces;

namespace LoadDistributionForTeachers.WEB.Util
{
    public class DependencesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAcademicDegreeService>().To<AcademicDegreeService>();
            Bind<IAcademicTitleService>().To<AcademicTitleService>();
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<IDisciplineService>().To<DisciplineService>();
            Bind<IAcademicPlanService>().To<AcademicPlanService>();
            Bind<ISubgroupService>().To<SubgroupService>();
            //Bind<ITypeOfEmployeeService>().To<TypeOfEmployeeService>();
            Bind<IContentOfThePlanService>().To<ContentOfThePlanService>();
            Bind<ILoadSubgroupService>().To<LoadSubgroupService>();
            Bind<ILectureFlowService>().To<LectureFlowService>();
            Bind<ILoadFlowService>().To<LoadFlowService>();
        }
    }
}