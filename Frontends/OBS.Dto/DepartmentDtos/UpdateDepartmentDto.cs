using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Dto.DepartmentDtos
{
    public class UpdateDepartmentDto
    {
        public int departmentID { get; set; }
        public string departmentName { get; set; }
        public int facultyID { get; set; }
    }
}
