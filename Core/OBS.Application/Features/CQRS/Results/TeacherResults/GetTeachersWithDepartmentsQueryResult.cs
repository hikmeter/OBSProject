using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Results.TeacherResults
{
    public class GetTeachersWithDepartmentsQueryResult
    {
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
