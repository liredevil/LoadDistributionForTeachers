using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Entities
{
    public class LectureFlow
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<Subgroup> Subgroups { get; set; }
        public ICollection<LoadFlow> LoadFlows { get; set; }
    }
}
