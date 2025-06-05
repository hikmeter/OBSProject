using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Dto.TeacherDtos
{
    public class CreateTeacherDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string title { get; set; }
        public int departmentID { get; set; }
    }
}
