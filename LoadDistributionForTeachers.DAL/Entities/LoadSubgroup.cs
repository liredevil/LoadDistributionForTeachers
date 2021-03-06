﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Entities
{
    public class LoadSubgroup
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        public int ContentOfThePlanId { get; set; }
        public ContentOfThePlan ContentOfThePlan { get; set; }

        [Required]
        public int SubgroupId { get; set; }
        public Subgroup Subgroup { get; set; }
    }
}
