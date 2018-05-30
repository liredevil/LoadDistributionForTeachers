using AutoMapper;
using LoadDistributionForTeachers.BLL.DTO;
using LoadDistributionForTeachers.BLL.Infrastructure;
using LoadDistributionForTeachers.BLL.Interfaces;
using LoadDistributionForTeachers.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoadDistributionForTeachers.WEB.Controllers
{
    public class LoadSubgroupController : Controller
    {
        ILoadSubgroupService loadService;
        ISubgroupService subgroupService;
        IEmployeeService employeeService;
        IContentOfThePlanService contentOfThePlanService;
        IDisciplineService disciplineService;

        public LoadSubgroupController(ILoadSubgroupService loadService, IContentOfThePlanService contentOfThePlanService, ISubgroupService subgroupService, IEmployeeService employeeService, IDisciplineService disciplineService)
        {
            this.loadService = loadService;
            this.subgroupService = subgroupService;
            this.employeeService = employeeService;
            this.contentOfThePlanService = contentOfThePlanService;
            this.disciplineService = disciplineService;
            
        }

        // GET: Load
        public ActionResult Index()
        {
            IEnumerable<LoadSubgroupDTO> loadDTOs = loadService.GetLoads();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LoadSubgroupDTO, LoadSubgroupViewModel>())
            .CreateMapper();

            var loads = mapper.Map<IEnumerable<LoadSubgroupDTO>, List<LoadSubgroupViewModel>>(loadDTOs);
            

            return View(loads);
        }

        [HttpGet]
        public ActionResult CreateLoad()
        {
            IEnumerable<EmployeeDTO> employeeDTOs = employeeService.GetEmployees();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var employees = mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(employeeDTOs);
            SelectList employeesList = new SelectList(employees, "Id", "LastName");
            ViewBag.Employees = employeesList;

            IEnumerable<DisciplineDTO> disciplineDTOs = disciplineService.GetDisciplines();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<DisciplineDTO, DisciplineViewModel>()).CreateMapper();
            var disciplines = mapper.Map<IEnumerable<DisciplineDTO>, List<DisciplineViewModel>>(disciplineDTOs);
            SelectList disciplinesList = new SelectList(disciplines, "Id", "Name");
            ViewBag.Disciplines = disciplinesList;

            IEnumerable<ContentOfThePlanDTO> contentOfThePlanDTOs = contentOfThePlanService.GetContentOfThePlans();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<ContentOfThePlanDTO, ContentOfThePlanViewModel>()).CreateMapper();
            var contentOfThePlans = mapper.Map<IEnumerable<ContentOfThePlanDTO>, List<ContentOfThePlanViewModel>>(contentOfThePlanDTOs);
            SelectList contentOfThePlansList = new SelectList(contentOfThePlans, "Id", "Id");
            ViewBag.ContentOfThePlans = contentOfThePlansList;

            IEnumerable<SubgroupDTO> subgroupDTOs = subgroupService.GetSubgroups();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<SubgroupDTO, SubgroupViewModel>()).CreateMapper();
            var subgroups = mapper.Map<IEnumerable<SubgroupDTO>, List<SubgroupViewModel>>(subgroupDTOs);
            SelectList subgroupsList = new SelectList(subgroups, "Id", "GroupNumber");
            ViewBag.Subgroups = subgroupsList;

            return View();
        }

        [HttpPost]
        public ActionResult CreateLoad(LoadSubgroupViewModel loadViewModel, int Employee/*, int Discipline*/, int ContentOfThePlan, int GroupNumber)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loadDTO = new LoadSubgroupDTO
                    {
                        EmployeeId = Employee,
                        //DisciplineId = Discipline,
                        ContentOfThePlanId = ContentOfThePlan,
                        SubgroupId = GroupNumber
                    };

                    loadService.CreateLoad(loadDTO);

                    TempData["message"] = string.Format("Load successful added");

                    return RedirectToAction("index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(loadViewModel);
        }

        public ActionResult DeleteLoad(int id)
        {
            try
            {
                loadService.DeleteLoad(id);

                TempData["message"] = string.Format("Нагрузка была удалена");

                return RedirectToAction("index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return RedirectToAction("index");
        }

        public JsonResult GetRegions(int Id)
        {
            IEnumerable<ContentOfThePlanDTO> contentOfThePlanDTOs = contentOfThePlanService.GetContentOfThePlans();
            var a = contentOfThePlanDTOs.Where(c => c.Id == Id).ToList().Select(x => new
            {
                Name = x.DisciplineTitle
            }).ToList();
            return Json(contentOfThePlanDTOs.Where(c => c.Id == Id).ToList().Select(x => new
            {
                Name = x.DisciplineTitle,
                NumberOfHoursOfLectures = x.NumberOfHoursOfLectures,
                NumberOfHoursOfPractice = x.NumberOfHoursOfPractice

            }).ToList());
            //return Json(db.Regiones.Where(r => r.CountryId == Id).Select(x => new
            //{
            //    Id = x.Id,
            //    Name = x.Name
            //}).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            loadService.Dispose();
            subgroupService.Dispose();
            employeeService.Dispose();
            contentOfThePlanService.Dispose();
            disciplineService.Dispose();
            base.Dispose(disposing);
        }
    }
}