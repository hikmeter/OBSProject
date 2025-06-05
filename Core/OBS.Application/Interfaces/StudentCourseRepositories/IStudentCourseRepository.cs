using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Interfaces.StudentCourseRepositories
{
    public interface IStudentCourseRepository
    {
        List<StudentCourse> GetCoursesByStudentID(int studentID);
    }
}
