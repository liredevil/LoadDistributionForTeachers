﻿using System;
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

        public SubgroupController(ISubgroupService subgroupService)
        {
            this.subgroupService = subgroupService;
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
            return View();
        }

        [HttpPost]
        public ActionResult CreateSubgroup(SubgroupViewModel subgroupViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var subgroupDTO = new SubgroupDTO
                    {
                        GroupNumber = subgroupViewModel.GroupNumber,
                        NumberOfStudents = subgroupViewModel.NumberOfStudents
                    };

                    subgroupService.CreateSubgroup(subgroupDTO);

                    TempData["message"] = string.Format("Subgroup successful added");

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

                TempData["message"] = string.Format("Subgroup successful deleted");

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
            base.Dispose(disposing);
        }
    }
}