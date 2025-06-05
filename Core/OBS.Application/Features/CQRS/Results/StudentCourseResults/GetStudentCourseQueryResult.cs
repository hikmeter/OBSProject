using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Results.StudentCourseResults
{
    public class GetStudentCourseQueryResult
    {
        public int StudentCourseID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public string Semester { get; set; }
        public bool IsPassed { get; set; }
        public string LetterGrade { get; set; }
    }
}
