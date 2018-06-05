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
    public class SubgroupController : Controller
    {
        ISubgroupService subgroupService;
        ILectureFlowService lectureFlowService;

        public SubgroupController(ISubgroupService subgroupService, ILectureFlowService lectureFlowService)
        {
            this.subgroupService = subgroupService;
            this.lectureFlowService = lectureFlowService;
        }

        // GET: Subgroup
        public ActionResult Index()
        {
            IEnumerable<SubgroupDTO> subgroupDTOs = subgroupService.GetSubgroups();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SubgroupDTO, SubgroupViewModel>()).CreateMapper();
            var subgroups = mapper.Map<IEnumerable<SubgroupDTO>, List<SubgroupViewModel>>(subgroupDTOs);

            return View(subgroups);
        }

        [HttpGet]
        public ActionResult CreateSubgroup()
        {
            IEnumerable<LectureFlowDTO> lectureFlowDTOs = lectureFlowService.GetLectureFlows();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LectureFlowDTO, LectureFlowViewModel>()).CreateMapper();
            var lectureFlows = mapper.Map<IEnumerable<LectureFlowDTO>, List<LectureFlowViewModel>>(lectureFlowDTOs);

            SelectList lectureFlowsList = new SelectList(lectureFlows, "Id", "Title");
            ViewBag.LectureFlows = lectureFlowsList;

            return View();
        }

        [HttpPost]
        public ActionResult CreateSubgroup(SubgroupViewModel subgroupViewModel,int lectureFlowId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var subgroupDTO = new SubgroupDTO
                    {
                        GroupNumber = subgroupViewModel.GroupNumber,
                        GroupNumber2 = subgroupViewModel.GroupNumber2,
                        NumberOfStudents = subgroupViewModel.NumberOfStudents,
                        LectureFlowId = lectureFlowId
                    };

                    subgroupService.CreateSubgroup(subgroupDTO);

                    TempData["message"] = string.Format("Подгруппа была добавлена");

                    return RedirectToAction("index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(subgroupViewModel);
        }

        public ActionResult DeleteSubgroup(int id)
        {
            try
            {
                subgroupService.DeleteSubgroup(id);

                TempData["message"] = string.Format("Подгруппа была удалена");

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
            subgroupService.Dispose();
            lectureFlowService.Dispose();
            base.Dispose(disposing);
        }
    }
}