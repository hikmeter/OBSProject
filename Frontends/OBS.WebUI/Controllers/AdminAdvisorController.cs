using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OBS.Dto.AdvisorDtos;
using OBS.Dto.StudentDtos;
using OBS.Dto.TeacherDtos;
using System.Text;

namespace OBS.WebUI.Controllers
{
    public class AdminAdvisorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminAdvisorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7245/api/Advisors/GetAdvisorWithTeacherAndStudent");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAdvisorsWithTeachersAndStudents>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateAdvisor()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7245/api/Teachers");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var responseMessage2 = await client.GetAsync("https://localhost:7245/api/Students");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTeacherDto>>(jsonData);
            List<SelectListItem> teacherValues = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.name + " " + x.surname,
                                                      Value = x.teacherID.ToString()
                                                  }).ToList();
            ViewBag.TeacherValues = teacherValues;
            var values2 = JsonConvert.DeserializeObject<List<ResultStudentDto>>(jsonData2);
            List<SelectListItem> studentValues = (from x in values2
                                                  select new SelectListItem
                                                  {
                                                      Text = x.name + " " + x.surname,
                                                      Value = x.studentID.ToString()
                                                  }).ToList();
            ViewBag.StudentValues = studentValues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvisor(CreateAdvisorDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7245/api/Advisors", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> RemoveAdvisor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7245/api/Advisors?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAdvisor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7245/api/Teachers");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTeacherDto>>(jsonData);
            List<SelectListItem> teacherValues = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.name + " " + x.surname,
                                                      Value = x.teacherID.ToString()
                                                  }).ToList();
            ViewBag.TeacherValues = teacherValues;
            var responseMessage2 = await client.GetAsync("https://localhost:7245/api/Students");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultStudentDto>>(jsonData2);
            List<SelectListItem> studentValues = (from x in values2
                                                  select new SelectListItem
                                                  {
                                                      Text = x.name + " " + x.surname,
                                                      Value = x.studentID.ToString()
                                                  }).ToList();
            ViewBag.StudentValues = studentValues;
            var responseMessage3 = await client.GetAsync($"https://localhost:7245/api/Advisors/{id}");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<UpdateAdvisorDto>(jsonData3);
                return View(values3);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAdvisor(UpdateAdvisorDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7245/api/Advisors", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
