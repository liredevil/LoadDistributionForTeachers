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
    public class LectureFlowController : Controller
    {
        ILectureFlowService lectureFlowService;

        public LectureFlowController(ILectureFlowService lectureFlowService)
        {
            this.lectureFlowService = lectureFlowService;
        }

        // GET: LectureFlow
        public ActionResult Index()
        {
            IEnumerable<LectureFlowDTO> lectureFlowDTOs = lectureFlowService.GetLectureFlows();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LectureFlowDTO, LectureFlowViewModel>()).CreateMapper();
            var disciplines = mapper.Map<IEnumerable<LectureFlowDTO>, List<LectureFlowViewModel>>(lectureFlowDTOs);

            return View(disciplines);
        }

        [HttpGet]
        public ActionResult CreateLectureFlow()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLectureFlow(LectureFlowViewModel lectureFlowViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lectureFlowDTO = new LectureFlowDTO
                    {
                        Title = lectureFlowViewModel.Title
                    };

                    lectureFlowService.CreateLectureFlow(lectureFlowDTO);

                    TempData["message"] = string.Format("Поток был была добавлена");

                    return RedirectToAction("index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(lectureFlowViewModel);
        }

        public ActionResult DeleteLectureFlow(int id)
        {
            try
            {
                lectureFlowService.DeleteLectureFlow(id);

                TempData["message"] = string.Format("Поток была удалена");

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
            lectureFlowService.Dispose();
            base.Dispose(disposing);
        }
    }
}