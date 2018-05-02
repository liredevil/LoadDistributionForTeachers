using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Entities
{
    public class Discipline
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ContentOfThePlan> ContentOfThePlans { get; set; }
    }
}
