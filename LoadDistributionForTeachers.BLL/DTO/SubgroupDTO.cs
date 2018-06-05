using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionForTeachers.BLL.DTO
{
    public class SubgroupDTO
    {
        public int Id { get; set; }

        public int NumberOfStudents { get; set; }

        public int GroupNumber { get; set; }//подгруппа
        public int GroupNumber2 { get; set; }///номер группы

        public int LectureFlowId { get; set; }
        public string LectureFlowTitle { get; set; }

    }
}
