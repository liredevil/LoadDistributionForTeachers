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
    public class AcademicDegreeController : Controller
    {
        IAcademicDegreeService academicDegreeService;

        public AcademicDegreeController(IAcademicDegreeService service)
        {
            academicDegreeService = service;
        }

        // GET: AcademicDegree
        public ActionResult Index()
        {
            IEnumerable<AcademicDegreeDTO> academicDegreeDTOs = academicDegreeService.GetAcademicDegrees();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AcademicDegreeDTO, AcademicDegreeViewModel>()).CreateMapper();
            var academicDegrees = mapper.Map<IEnumerable<AcademicDegreeDTO>, List<AcademicDegreeViewModel>>(academicDegreeDTOs);

            return View(academicDegrees);
        }

        [HttpGet]
        public ActionResult CreateAcademicDegree()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAcademicDegree(AcademicDegreeViewModel academicDegreeViewModel )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var academicDegreeDTO = new AcademicDegreeDTO
                    {
                        Title = academicDegreeViewModel.Title
                    };

                    academicDegreeService.CreateAcademicDegree(academicDegreeDTO);

                    TempData["message"] = string.Format("Ученая степень была добавлена");

                    return RedirectToAction("index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(academicDegreeViewModel);
        }

        public ActionResult DeleteAcademicDegree(int id)
        {
            try
            {
                academicDegreeService.DeleteAcademicDegree(id);

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
            academicDegreeService.Dispose();
            base.Dispose(disposing);
        }
    }
}