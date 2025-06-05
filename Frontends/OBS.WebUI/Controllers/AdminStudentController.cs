using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OBS.Dto.CourseDtos;
using OBS.Dto.DepartmentDtos;
using OBS.Dto.StudentDtos;
using System.Text;

namespace OBS.WebUI.Controllers
{
    public class AdminStudentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStudentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<PartialViewResult> SearchStudent(string studentNo, string name, string surname, string departmentName)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7245/api/Students/GetStudentWithDepartment");
            if (!responseMessage.IsSuccessStatusCode)
                return PartialView(new List<GetStudentsWithDepartmentsDto>());

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetStudentsWithDepartmentsDto>>(jsonData);

            var filtered = values.Where(x =>
    (string.IsNullOrEmpty(studentNo) || x.studentNo.Contains(studentNo, StringComparison.OrdinalIgnoreCase)) &&
    (string.IsNullOrEmpty(name) || x.name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
    (string.IsNullOrEmpty(surname) || x.surname.Contains(surname, StringComparison.OrdinalIgnoreCase)) &&
    (string.IsNullOrEmpty(departmentName) || x.departmentName.Contains(departmentName, StringComparison.OrdinalIgnoreCase))).ToList();
            return PartialView(filtered);
        }
        [HttpGet]
        public async Task<IActionResult> CreateStudent()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7245/api/Departments");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDepartmentDto>>(jsonData);
            List<SelectListItem> departmentValues = (from x in values
                                                     select new SelectListItem
                                                     {
                                                         Text = x.departmentName,
                                                         Value = x.departmentID.ToString()
                                                     }).ToList();
            ViewBag.DepartmentValues = departmentValues;
            Random random = new Random();
            int yil = random.Next(0, 6);
            int bolum = random.Next(1, 10) * 10;
            int tur = random.Next(1, 3);
            int sira = random.Next(0, 100);
            string sNumber = $"2{yil}{bolum:00}0{tur}0{sira:00}";
            ViewBag.SNumber = sNumber;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7245/api/Students", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> RemoveStudent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7245/api/Students?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStudent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7245/api/Departments");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultDepartmentDto>>(jsonData1);
            List<SelectListItem> departmentValues = (from x in values1
                                                     select new SelectListItem
                                                     {
                                                         Text = x.departmentName,
                                                         Value = x.departmentID.ToString()
                                                     }).ToList();
            ViewBag.DepartmentValues = departmentValues;
            var responseMessage = await client.GetAsync($"https://localhost:7245/api/Students/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStudentDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStudent(UpdateStudentDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7245/api/Students", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
