using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Dto.ExamDtos
{
    public class CreateExamDto
    {
        public int courseID { get; set; }
        public int teacherID { get; set; }
        public string examName { get; set; }
        public int weight { get; set; }
        public DateTime createdTime { get; set; }
    }
}
