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
    public class TypeOfEmployeeController : Controller
    {
        ITypeOfEmployeeService employeeService;

        public TypeOfEmployeeController(ITypeOfEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // GET: TypeOfEmployee
        public ActionResult Index()
        {
            IEnumerable<TypeOfEmployeeDTO> typeOfEmployeeDTOs = employeeService.GetTypeOfEmployees();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeOfEmployeeDTO, Type>()).CreateMapper();
            var typeOfEmployees = mapper.Map<IEnumerable<TypeOfEmployeeDTO>, List<TypeOfEmployeeViewModel>>(typeOfEmployeeDTOs);

            return View(typeOfEmployees);
        }

        [HttpGet]
        public ActionResult CreateTypeOfEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTypeOfEmployee(TypeOfEmployeeViewModel typeOfEmployeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var typeOfEmployeeDTO = new TypeOfEmployeeDTO
                    {
                        Title = typeOfEmployeeViewModel.Title
                    };

                    employeeService.CreateTypeOfEmployee(typeOfEmployeeDTO);

                    TempData["message"] = string.Format("TypeOfEmployee successful added");

                    return RedirectToAction("index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(typeOfEmployeeViewModel);
        }

        public ActionResult DeleteTypeOfEmployee(int id)
        {
            try
            {
                employeeService.DeleteTypeOfEmployee(id);

                TempData["message"] = string.Format("TypeOfEmployee successful deleted");

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
            base.Dispose(disposing);
        }
    }
}