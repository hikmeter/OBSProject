using OBS.Application.Features.CQRS.Handlers.CourseHandlers;
using OBS.Application.Features.CQRS.Handlers.DepartmentHandlers;
using OBS.Application.Features.CQRS.Handlers.FacultyHandlers;
using OBS.Application.Features.CQRS.Handlers.ExamHandlers;
using OBS.Application.Features.CQRS.Handlers.StudentHandlers;
using OBS.Application.Features.CQRS.Handlers.StudentCourseHandlers;
using OBS.Application.Features.CQRS.Handlers.StudentExamHandlers;
using OBS.Application.Features.CQRS.Handlers.TeacherHandlers;
using OBS.Application.Features.CQRS.Handlers.AdvisorHandlers;
using OBS.Application.Interfaces;
using OBS.Persistence.Repositories;
using OBSPersistence.Context;
using OBS.Application.Interfaces.CourseRepositories;
using OBS.Persistence.Repositories.CourseRepositories;
using OBS.Application.Interfaces.DepartmentRepositories;
using OBS.Persistence.Repositories.DepartmentRepositories;
using OBS.Application.Interfaces.ExamRepositories;
using OBS.Persistence.Repositories.ExamRepositories;
using OBS.Application.Interfaces.StudentRepositories;
using OBS.Persistence.Repositories.StudentRepositories;
using OBS.Application.Interfaces.StudentCourseRepositories;
using OBS.Persistence.Repositories.StudentCourseRepositories;
using OBS.Application.Interfaces.TeacherRepositories;
using OBS.Persistence.Repositories.TeacherRepositories;
using OBS.Application.Interfaces.AdvisorRepositories;
using OBS.Persistence.Repositories.AdvisorRepositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddScoped<OBSContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); 
builder.Services.AddScoped(typeof(ICourseRepository), typeof(CourseRepository)); 
builder.Services.AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepository)); 
builder.Services.AddScoped(typeof(IExamRepository), typeof(ExamRepository)); 
builder.Services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository)); 
builder.Services.AddScoped(typeof(IStudentCourseRepository), typeof(StudentCourseRepository)); 
builder.Services.AddScoped(typeof(ITeacherRepository), typeof(TeacherRepository)); 
builder.Services.AddScoped(typeof(IAdvisorRepository), typeof(AdvisorRepository)); 
builder.Services.AddScoped<GetCourseByIdQueryHandler>();
builder.Services.AddScoped<GetCourseQueryHandler>();
builder.Services.AddScoped<GetCoursesWithDepartmentsQueryHandler>();
builder.Services.AddScoped<CreateCourseCommandHandler>();
builder.Services.AddScoped<UpdateCourseCommandHandler>();
builder.Services.AddScoped<RemoveCourseCommandHandler>();
builder.Services.AddScoped<GetDepartmentByIdQueryHandler>();
builder.Services.AddScoped<GetDepartmentQueryHandler>();
builder.Services.AddScoped<GetDepartmentsWithFacultiesQueryHandler>();
builder.Services.AddScoped<CreateDepartmentCommandHandler>();
builder.Services.AddScoped<UpdateDepartmentCommandHandler>();
builder.Services.AddScoped<RemoveDepartmentCommandHandler>();
builder.Services.AddScoped<GetFacultyByIdQueryHandler>();
builder.Services.AddScoped<GetFacultyQueryHandler>();
builder.Services.AddScoped<CreateFacultyCommandHandler>();
builder.Services.AddScoped<UpdateFacultyCommandHandler>();
builder.Services.AddScoped<RemoveFacultyCommandHandler>();
builder.Services.AddScoped<GetExamByIdQueryHandler>();
builder.Services.AddScoped<GetExamQueryHandler>();
builder.Services.AddScoped<GetExamsWithCoursesAndTeachersQueryHandler>();
builder.Services.AddScoped<CreateExamCommandHandler>();
builder.Services.AddScoped<UpdateExamCommandHandler>();
builder.Services.AddScoped<RemoveExamCommandHandler>();
builder.Services.AddScoped<GetStudentByIdQueryHandler>();
builder.Services.AddScoped<GetStudentQueryHandler>();
builder.Services.AddScoped<GetStudentsWithDepartmentsQueryHandler>();
builder.Services.AddScoped<CreateStudentCommandHandler>();
builder.Services.AddScoped<UpdateStudentCommandHandler>();
builder.Services.AddScoped<RemoveStudentCommandHandler>();
builder.Services.AddScoped<GetStudentCourseByIdQueryHandler>();
builder.Services.AddScoped<GetStudentCourseQueryHandler>();
builder.Services.AddScoped<GetStudentCoursesByStudentIdQueryHandler>();
builder.Services.AddScoped<CreateStudentCourseCommandHandler>();
builder.Services.AddScoped<UpdateStudentCourseCommandHandler>();
builder.Services.AddScoped<RemoveStudentCourseCommandHandler>();
builder.Services.AddScoped<GetStudentExamByIdQueryHandler>();
builder.Services.AddScoped<GetStudentExamQueryHandler>();
builder.Services.AddScoped<CreateStudentExamCommandHandler>();
builder.Services.AddScoped<UpdateStudentExamCommandHandler>();
builder.Services.AddScoped<RemoveStudentExamCommandHandler>();
builder.Services.AddScoped<GetTeacherByIdQueryHandler>();
builder.Services.AddScoped<GetTeacherQueryHandler>();
builder.Services.AddScoped<GetTeachersWithDepartmentsQueryHandler>();
builder.Services.AddScoped<CreateTeacherCommandHandler>();
builder.Services.AddScoped<UpdateTeacherCommandHandler>();
builder.Services.AddScoped<RemoveTeacherCommandHandler>();
builder.Services.AddScoped<GetAdvisorByIdQueryHandler>();
builder.Services.AddScoped<GetAdvisorQueryHandler>();
builder.Services.AddScoped<GetAdvisorsWithTeachersAndStudentsQueryHandler>();
builder.Services.AddScoped<CreateAdvisorCommandHandler>();
builder.Services.AddScoped<UpdateAdvisorCommandHandler>();
builder.Services.AddScoped<RemoveAdvisorCommandHandler>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
