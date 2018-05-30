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
    [Authorize]
    public class AcademicTitleController : Controller
    {
        IAcademicTitleService academicTitleService;

        public AcademicTitleController(IAcademicTitleService academicTitleService)
        {
            this.academicTitleService = academicTitleService;
        }

        // GET: AcademicTitle
        public ActionResult Index()
        {
            IEnumerable<AcademicTitleDTO> academicTitleDTOs = academicTitleService.GetAcademicTitles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AcademicTitleDTO, AcademicTitleViewModel>()).CreateMapper();
            var academicTitles = mapper.Map<IEnumerable<AcademicTitleDTO>, List<AcademicTitleViewModel>>(academicTitleDTOs);

            return View(academicTitles);
        }

        [HttpGet]
        public ActionResult CreateAcademicTitle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAcademicTitle(AcademicTitleViewModel academicTitleViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var academicTitleDTO = new AcademicTitleDTO
                    {
                        Title = academicTitleViewModel.Title
                    };

                    academicTitleService.CreateAcademicTitle(academicTitleDTO);

                    TempData["message"] = string.Format("Ученая степень была добавлена");

                    return RedirectToAction("index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(academicTitleViewModel);
        }

        public ActionResult DeleteAcademicTitle(int id)
        {
            try
            {
                academicTitleService.DeleteAcademicTitle(id);

                TempData["message"] = string.Format("Ученая степень была удалена");

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
            academicTitleService.Dispose();
            base.Dispose(disposing);
        }
    }
}