using OBS.Application.Features.CQRS.Results.AdvisorResults;
using OBS.Application.Interfaces.AdvisorRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.AdvisorHandlers
{
    public class GetAdvisorsWithTeachersAndStudentsQueryHandler
    {
        private readonly IAdvisorRepository _repository;
        public GetAdvisorsWithTeachersAndStudentsQueryHandler(IAdvisorRepository repository)
        {
            _repository = repository;
        }
        public List<GetAdvisorsWithTeachersAndStudentsQueryResult> Handle()
        {
            var values = _repository.GetAdvisorsWithTeachersAndStudents();
            return values.Select(x => new GetAdvisorsWithTeachersAndStudentsQueryResult
            {
                AdvisorID = x.AdvisorID,
                MeetingDay = x.MeetingDay,
                MeetingTime = x.MeetingTime,
                StudentID = x.StudentID,
                StudentName = x.Student.Name,
                StudentSurname = x.Student.Surname,
                TeacherID = x.TeacherID,
                TeacherName = x.Teacher.Name,
                TeacherSurname = x.Teacher.Surname
            }).ToList();
        }
    }
}
