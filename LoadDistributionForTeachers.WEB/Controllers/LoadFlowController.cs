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
    public class LoadFlowController : Controller
    {
        ILoadFlowService loadFlowService;
        ILectureFlowService lectureFlowService;
        IEmployeeService employeeService;
        IContentOfThePlanService contentOfThePlanService;
        IDisciplineService disciplineService;

        public LoadFlowController(ILoadFlowService loadFlowService, IContentOfThePlanService contentOfThePlanService, ILectureFlowService lectureFlowService, IEmployeeService employeeService, IDisciplineService disciplineService)
        {
            this.loadFlowService = loadFlowService;
            this.lectureFlowService = lectureFlowService;
            this.employeeService = employeeService;
            this.contentOfThePlanService = contentOfThePlanService;
            this.disciplineService = disciplineService;
        }

        // GET: LoadFlow
        public ActionResult Index()
        {
            IEnumerable<LoadFlowDTO> lectureFlowDTOs = loadFlowService.GetLoadFlows();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LoadFlowDTO, LoadFlowViewModel>()).CreateMapper();
            var disciplines = mapper.Map<IEnumerable<LoadFlowDTO>, List<LoadFlowViewModel>>(lectureFlowDTOs);

            return View(disciplines);
        }

        [HttpGet]
        public ActionResult CreateLoad()
        {
            IEnumerable<EmployeeDTO> employeeDTOs = employeeService.GetEmployees();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var employees = mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(employeeDTOs);
            SelectList employeesList = new SelectList(employees, "Id", "LastName");
            ViewBag.Employees = employeesList;

            //IEnumerable<DisciplineDTO> disciplineDTOs = disciplineService.GetDisciplines();
            //mapper = new MapperConfiguration(cfg => cfg.CreateMap<DisciplineDTO, DisciplineViewModel>()).CreateMapper();
            //var disciplines = mapper.Map<IEnumerable<DisciplineDTO>, List<DisciplineViewModel>>(disciplineDTOs);
            //SelectList disciplinesList = new SelectList(disciplines, "Id", "Name");
            //ViewBag.Disciplines = disciplinesList;

            IEnumerable<ContentOfThePlanDTO> contentOfThePlanDTOs = contentOfThePlanService.GetContentOfThePlans();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<ContentOfThePlanDTO, ContentOfThePlanViewModel>()).CreateMapper();
            var contentOfThePlans = mapper.Map<IEnumerable<ContentOfThePlanDTO>, List<ContentOfThePlanViewModel>>(contentOfThePlanDTOs);
            SelectList contentOfThePlansList = new SelectList(contentOfThePlans, "Id", "Id");
            ViewBag.ContentOfThePlans = contentOfThePlansList;

            IEnumerable<LectureFlowDTO> lectureFlowDTOs = lectureFlowService.GetLectureFlows();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<LectureFlowDTO, LectureFlowViewModel>()).CreateMapper();
            var subgroups = mapper.Map<IEnumerable<LectureFlowDTO>, List<LectureFlowViewModel>>(lectureFlowDTOs);
            SelectList lectureFlowList = new SelectList(subgroups, "Id", "Title");
            ViewBag.LectureFlows = lectureFlowList;

            return View();
        }

        [HttpPost]
        public ActionResult CreateLoad(LoadFlowDTO loadViewModel, int Employee, int ContentOfThePlan,int LectureFlow)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loadDTO = new LoadFlowDTO
                    {
                        EmployeeId = Employee,
                        ContentOfThePlanId = ContentOfThePlan,
                        LectureFlowId = LectureFlow
                    };

                    loadFlowService.CreateLoadFlow(loadDTO);

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
                loadFlowService.DeleteLoadFlow(id);

                TempData["message"] = string.Format("Нагрузка была удалена");

                return RedirectToAction("index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult CountLoad()
        {
            IEnumerable<LoadFlowDTO> loadDTOs = loadFlowService.GetLoadFlows();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LoadFlowDTO, LoadFlowViewModel>())
            .CreateMapper();

            var loads = mapper.Map<IEnumerable<LoadFlowDTO>, List<LoadFlowViewModel>>(loadDTOs);


            List<LoadFlowViewModel> getList = new List<LoadFlowViewModel>();
            foreach (var item in loads)
            {
                getList.Add(new LoadFlowViewModel
                {
                    Name = item.Name,
                    //NumberOfHoursOfLectures = item.NumberOfHoursOfLectures,
                    NumberOfHoursOfLectures = item.NumberOfHoursOfLectures,
                    NumberOfHoursOfOffset = item.NumberOfHoursOfOffset,
                    NumberOfHoursOfExamination = item.NumberOfHoursOfExamination
                });
            }
            //int a = 0;
            int b = 0;
            List<LoadFlowViewModel> newGetList = new List<LoadFlowViewModel>();
            int count = newGetList.Count();///счетчик
            int flag = 0;
            for (int i = 0; i < getList.Count; i++)
            {
                //a = getList[i].NumberOfHoursOfLectures;
                b = getList[i].NumberOfHoursOfLectures + getList[i].NumberOfHoursOfOffset + getList[i].NumberOfHoursOfExamination;
                for (int j = i + 1; j < getList.Count; j++)
                {
                    if (getList[i].Name == getList[j].Name)
                    {
                        //a += getList[j].NumberOfHoursOfLectures;
                        b += getList[j].NumberOfHoursOfLectures + getList[j].NumberOfHoursOfOffset + getList[j].NumberOfHoursOfExamination;
                    }
                }

                for (int i1 = 0; i1 < newGetList.Count; i1++)
                {
                    if (newGetList[i1].Name == getList[i].Name)
                    {
                        flag = 1;
                    }
                }
                if (flag != 1)
                {
                    newGetList.Add(new LoadFlowViewModel
                    {
                        Name = getList[i].Name,
                        //NumberOfHoursOfLectures = a,
                        NumberOfHoursOfLectures = b
                    });
                }

                //a = 0;
                b = 0;
                flag = 0;
            }
            return View(newGetList);
        }

        public JsonResult GetRegions(int Id)
        {
            IEnumerable<ContentOfThePlanDTO> contentOfThePlanDTOs = contentOfThePlanService.GetContentOfThePlans();

            return Json(contentOfThePlanDTOs.Where(c => c.Id == Id).ToList().Select(x => new
            {
                Name = x.DisciplineTitle,
                NumberOfHoursOfLectures = x.NumberOfHoursOfLectures,
                Reporting = x.Reporting

            }).ToList());
            //return Json(db.Regiones.Where(r => r.CountryId == Id).Select(x => new
            //{
            //    Id = x.Id,
            //    Name = x.Name
            //}).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            loadFlowService.Dispose();
            lectureFlowService.Dispose();
            employeeService.Dispose();
            contentOfThePlanService.Dispose();
            disciplineService.Dispose();
            base.Dispose(disposing);
        }
    }
}