using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Results.StudentExamResults
{
    public class GetStudentExamQueryResult
    {
        public int StudentExamID { get; set; }
        public int StudentID { get; set; }
        public int ExamID { get; set; }
        public int Grade { get; set; }
        public DateTime GradedAt { get; set; }
    }
}
