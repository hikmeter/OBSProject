using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OBS.Dto.CourseDtos;
using OBS.Dto.DepartmentDtos;
using OBS.Dto.ExamDtos;
using OBS.Dto.FacultyDtos;
using System.Text;

namespace OBS.WebUI.Controllers
{
    public class AdminExamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminExamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<PartialViewResult> SearchResult(int? examID, string courseName, string teacherName, string teacherSurname, string examName, int? weight, DateTime? createdTime)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7245/api/Exams/GetExamWithCourseAndTeacher");
            if (!responseMessage.IsSuccessStatusCode)
                return PartialView(new List<GetExamsWithCoursesAndTeachersDto>());

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetExamsWithCoursesAndTeachersDto>>(jsonData);

            var filtered = values.Where(x =>
                (!examID.HasValue || x.examID == examID) &&
                (string.IsNullOrEmpty(courseName) || x.courseName.Contains(courseName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(teacherName) || x.teacherName.Contains(teacherName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(teacherSurname) || x.teacherSurname.Contains(teacherSurname, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(examName) || x.examName.Contains(examName, StringComparison.OrdinalIgnoreCase)) &&
                (!weight.HasValue || x.weight == weight) &&
                (!createdTime.HasValue || x.createdTime.Date == createdTime.Value.Date)
            ).ToList();

            return PartialView(filtered);
        }
        [HttpGet]
        public async Task<IActionResult> CreateExam()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7245/api/Courses");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCoursesDto>>(jsonData);
            List<SelectListItem> courseValues = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.courseName,
                                                      Value = x.courseID.ToString()
                                                  }).ToList();
            ViewBag.CourseValues = courseValues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateExam(CreateExamDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            dto.teacherID = 2;
            dto.createdTime = DateTime.Now;
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7245/api/Exams", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminExam");
            }
            return View();
        }
        public async Task<IActionResult> RemoveExam(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7245/api/Exams?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateExam(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7245/api/Exams/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateExamDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateExam(UpdateExamDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7245/api/Exams/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","AdminExam");
            }
            return View();
        }
    }
}
