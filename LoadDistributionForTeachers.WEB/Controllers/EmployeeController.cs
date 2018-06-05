using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoadDistributionForTeachers.BLL.Interfaces;
using LoadDistributionForTeachers.BLL.DTO;
using LoadDistributionForTeachers.WEB.Models;
using AutoMapper;
using LoadDistributionForTeachers.BLL.Infrastructure;


namespace LoadDistributionForTeachers.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;
        IAcademicDegreeService academicDegreeService;
        IAcademicTitleService academicTitleService;

        public EmployeeController(IEmployeeService employeeService, IAcademicDegreeService academicDegreeService,IAcademicTitleService academicTitleService) 
        {
            this.employeeService = employeeService;
            this.academicDegreeService = academicDegreeService;
            this.academicTitleService = academicTitleService;
        }

        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeDTO> employeeDTOs = employeeService.GetEmployees();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>())
            .CreateMapper();

            var employees = mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(employeeDTOs);

            return View(employees);
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            IEnumerable<AcademicDegreeDTO> academicDegreeDTOs = academicDegreeService.GetAcademicDegrees();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AcademicDegreeDTO, AcademicDegreeViewModel>()).CreateMapper();
            var academicDegrees = mapper.Map<IEnumerable<AcademicDegreeDTO>, List<AcademicDegreeViewModel>>(academicDegreeDTOs);

            SelectList academicDegreesList = new SelectList(academicDegrees, "Id", "Title");
            ViewBag.AcademicDegrees = academicDegreesList;

            IEnumerable<AcademicTitleDTO> academicTitleDTOs = academicTitleService.GetAcademicTitles();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<AcademicTitleDTO, AcademicTitleViewModel>()).CreateMapper();
            var academicTitles = mapper.Map<IEnumerable<AcademicTitleDTO>, List<AcademicTitleViewModel>>(academicTitleDTOs);

            SelectList academicTitlesList = new SelectList(academicTitles, "Id", "Title");
            ViewBag.AcademicTitles = academicTitlesList;

            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(EmployeeCreateModel employeeCreateModel, int academicDegreeTitle,int academicTitleName)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var employeeDTO = new EmployeeDTO {
                        FirstName = employeeCreateModel.FirstName,
                        LastName = employeeCreateModel.LastName,
                        Patronymic = employeeCreateModel.Patronymic,
                        AcademicDegreeDTOId = academicDegreeTitle,
                        AcademicTitleDTOId = academicTitleName
                    };

                    employeeService.CreateEmployee(employeeDTO);

                    TempData["message"] = string.Format("Сотрудник был добавлен");

                    return RedirectToAction("index");
                }
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(employeeCreateModel);
        }

        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                employeeService.DeleteEmployee(id);

                TempData["message"] = string.Format("Сотрудник был удален");

                return RedirectToAction("index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return RedirectToAction("index");
        }

        protected override void Dispose(bool disposing)
        {
            employeeService.Dispose();
            academicDegreeService.Dispose();
            academicTitleService.Dispose();
            base.Dispose(disposing);
        }
    }
}