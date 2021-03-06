﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Entities
{
    public class Subgroup
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int NumberOfStudents { get; set; }

        [Required]
        public int GroupNumber { get; set; }///номер подгруппы

        [Required]
        public int GroupNumber2 { get; set; }///номер группы

        public int LectureFlowId { get; set; }
        public LectureFlow LectureFlow { get; set; }
    }
}
