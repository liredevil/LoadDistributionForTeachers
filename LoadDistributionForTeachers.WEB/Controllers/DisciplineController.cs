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
    [Authorize]
    public class DisciplineController : Controller
    {
        IDisciplineService disciplineService;

        public DisciplineController(IDisciplineService disciplineService)
        {
            this.disciplineService = disciplineService;
        }

        // GET: Discipline
        public ActionResult Index()
        {
            IEnumerable<DisciplineDTO> disciplineDTOs = disciplineService.GetDisciplines();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DisciplineDTO, DisciplineViewModel>()).CreateMapper();
            var disciplines = mapper.Map<IEnumerable<DisciplineDTO>, List<DisciplineViewModel>>(disciplineDTOs);

            return View(disciplines);
        }

        [HttpGet]
        public ActionResult CreateDiscipline()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDiscipline(DisciplineViewModel disciplineViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var disciplineDTO = new DisciplineDTO
                    {
                        Name = disciplineViewModel.Name
                    };

                    disciplineService.CreateDiscipline(disciplineDTO);

                    TempData["message"] = string.Format("Дисциплина была добавлена");

                    return RedirectToAction("index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(disciplineViewModel);
        }

        public ActionResult DeleteDiscipline(int id)
        {
            try
            {
                disciplineService.DeleteDiscipline(id);

                TempData["message"] = string.Format("Дисциплина была удалена");

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
            disciplineService.Dispose();
            base.Dispose(disposing);
        }
    }
}