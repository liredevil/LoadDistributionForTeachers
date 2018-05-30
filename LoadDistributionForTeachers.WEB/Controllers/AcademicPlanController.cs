using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LoadDistributionForTeachers.BLL.DTO;
using LoadDistributionForTeachers.BLL.Infrastructure;
using LoadDistributionForTeachers.BLL.Interfaces;
using LoadDistributionForTeachers.WEB.Models;

namespace LoadDistributionForTeachers.WEB.Controllers
{
    public class AcademicPlanController : Controller
    {
        IAcademicPlanService academicPlanService;

        public AcademicPlanController(IAcademicPlanService academicPlanService)
        {
            this.academicPlanService = academicPlanService;
        }

        // GET: AcademicPlan
        public ActionResult Index()
        {
            IEnumerable<AcademicPlanDTO> academicPlanDTOs = academicPlanService.GetAcademicPlans();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AcademicPlanDTO, AcademicPlanViewModel>()).CreateMapper();
            var academicPlans = mapper.Map<IEnumerable<AcademicPlanDTO>, List<AcademicPlanViewModel>>(academicPlanDTOs);

            return View(academicPlans);
        }

        [HttpGet]
        public ActionResult CreateAcademicPlan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAcademicPlan(AcademicPlanViewModel academicPlanViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var academicPlanDTO = new AcademicPlanDTO
                    {
                        GroupCode = academicPlanViewModel.GroupCode,
                        NameOfSpecialty = academicPlanViewModel.NameOfSpecialty
                    };

                    academicPlanService.CreateAcademicPlan(academicPlanDTO);

                    TempData["message"] = string.Format("Учебный план был добавлен");

                    return RedirectToAction("index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(academicPlanViewModel);
        }

        public ActionResult DeleteAcademicPlan(int id)
        {
            try
            {
                academicPlanService.DeleteAcademicPlan(id);

                TempData["message"] = string.Format("Учебный план был удален");

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
            academicPlanService.Dispose();
            base.Dispose(disposing);
        }
    }
}