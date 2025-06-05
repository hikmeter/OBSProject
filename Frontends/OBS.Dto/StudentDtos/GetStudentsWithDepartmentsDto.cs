using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Dto.StudentDtos
{
    public class GetStudentsWithDepartmentsDto
    {
        public int studentID { get; set; }
        public string studentNo { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime birthDate { get; set; }
        public string gender { get; set; }
        public int departmentID { get; set; }
        public string departmentName { get; set; }
    }
}
