using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OBS.Dto.StudentCourseDtos;
using System.Net.Http;

namespace OBS.WebUI.Controllers
{
    public class AdminStudentCourseController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStudentCourseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Transcript(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7245/api/StudentCourses/GetStudentCourseWithCourseNameByStudentId?id={id}");
            ViewBag.StudentName = "Elif HALKA";
            ViewBag.DepartmentName = "İşletme Fakültesi";
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTranscriptDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
