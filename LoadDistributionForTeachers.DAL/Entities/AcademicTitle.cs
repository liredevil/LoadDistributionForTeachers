﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Entities
{
    public class AcademicTitle
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
