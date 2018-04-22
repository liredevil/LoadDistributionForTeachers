using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Entities
{
    public class AcademicDegree
    {
        [Required]
        public int Id { get; set; }

        
        public string Title { get; set; }

        public ICollection<AcademicDegreeEmployee> AcademicDegreeEmployees { get; set; }
    }
}
