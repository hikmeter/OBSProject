using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Domain.Entities
{
    public class StudentExam
    {
        public int StudentExamID { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int ExamID { get; set; }
        public Exam Exam { get; set; }
        public int Grade { get; set; }
        public DateTime GradedAt { get; set; }
    }
}
