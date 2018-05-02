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
    public class ContentOfThePlanController : Controller
    {
        IContentOfThePlanService contentOfThePlanService;
        IDisciplineService disciplineService;
        IAcademicPlanService academicPlanService;

        public ContentOfThePlanController(IContentOfThePlanService contentOfThePlanService,IDisciplineService disciplineService, IAcademicPlanService academicPlanService)
        {
            this.contentOfThePlanService = contentOfThePlanService;
            this.disciplineService = disciplineService;
            this.academicPlanService = academicPlanService;
        }

        // GET: ContentOfThePlan
        public ActionResult Index()
        {
            IEnumerable<ContentOfThePlanDTO> contentOfThePlanDTOs = contentOfThePlanService.GetContentOfThePlans();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ContentOfThePlanDTO, ContentOfThePlanViewModel>())
            .CreateMapper();

            var contentOfThePlans = mapper.Map<IEnumerable<ContentOfThePlanDTO>, List<ContentOfThePlanViewModel>>(contentOfThePlanDTOs);

            return View(contentOfThePlans);
        }

        [HttpGet]
        public ActionResult CreateContentOfThePlane()
        {
            IEnumerable<DisciplineDTO> disciplineDTOs = disciplineService.GetDisciplines();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DisciplineDTO, DisciplineViewModel>()).CreateMapper();
            var disciplines = mapper.Map<IEnumerable<DisciplineDTO>, List<DisciplineViewModel>>(disciplineDTOs);

            SelectList disciplinesList = new SelectList(disciplines, "Id", "Name");
            ViewBag.Disciplines = disciplinesList;

            IEnumerable<AcademicPlanDTO> academicPlanDTOs = academicPlanService.GetAcademicPlans();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<AcademicPlanDTO, AcademicPlanViewModel>()).CreateMapper();
            var academicPlans = mapper.Map<IEnumerable<AcademicPlanDTO>, List<AcademicPlanViewModel>>(academicPlanDTOs);

            SelectList academicPlansList = new SelectList(academicPlans, "Id", "GroupCode");
            ViewBag.AcademicPlans = academicPlansList;

            return View();
        }

        [HttpPost]
        public ActionResult CreateContentOfThePlane(ContentOfThePlanViewModel contentOfThePlanViewModel, int AcademicPlans, int Disciplines)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contentOfThePlanDTO = new ContentOfThePlanDTO
                    {
                        NumberOfHoursOfLectures = contentOfThePlanViewModel.NumberOfHoursOfLectures,
                        NumberOfHoursOfPractice = contentOfThePlanViewModel.NumberOfHoursOfPractice,
                        Reporting = contentOfThePlanViewModel.Reporting,
                        SemesterNumber = contentOfThePlanViewModel.SemesterNumber,
                        AcademicPlanId = AcademicPlans,
                        DisciplineId = Disciplines,
                    };

                    contentOfThePlanService.CreateContentOfThePlan(contentOfThePlanDTO);

                    TempData["message"] = string.Format("ContentOfThePlan successful added");

                    return RedirectToAction("index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(contentOfThePlanViewModel);
        }

        public ActionResult DeleteContentOfThePlane(int id)
        {
            try
            {
                contentOfThePlanService.DeleteContentOfThePlan(id);

                TempData["message"] = string.Format("ContentOfThePlane successful deleted");

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
            contentOfThePlanService.Dispose();
            disciplineService.Dispose();
            academicPlanService.Dispose();
            base.Dispose(disposing);
        }
    }
}