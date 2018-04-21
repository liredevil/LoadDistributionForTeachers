using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoadDistributionForTeachers.BLL.Interfaces;
using LoadDistributionForTeachers.BLL.DTO;
using LoadDistributionForTeachers.WEB.Models;
using AutoMapper;

namespace LoadDistributionForTeachers.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;

        public EmployeeController(IEmployeeService service)
        {
            employeeService = service;
        }

        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeDTO> employeeDTOs = employeeService.GetEmployees();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var employees = mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(employeeDTOs);

            return View(employees);
        }

        protected override void Dispose(bool disposing)
        {
            employeeService.Dispose();
            base.Dispose(disposing);
        }
    }
}