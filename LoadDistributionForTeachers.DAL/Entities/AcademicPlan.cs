using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.DAL.Entities
{
    public class AcademicPlan
    {
        public int Id { get; set; }
        public int GroupCode { get; set; }
        public string NameOfSpecialty { get; set; }

        public ICollection<ContentOfThePlan> ContentOfThePlans { get; set; }
    }
}
