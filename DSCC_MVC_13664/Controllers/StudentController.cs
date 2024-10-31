using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static System.Net.WebRequestMethods;

namespace DSCC_MVC_13664.Controllers
{
    public class StudentController : Controller
    {
        private readonly string Baseurl = "https://localhost:7274/";

        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            
            List<Student> Students = new List<Student>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Student");

                if (Res.IsSuccessStatusCode)
                {
                    var StResponse =  Res.Content.ReadAsStringAsync().Result;
                    Students = JsonConvert.DeserializeObject<List<Student>>(StResponse);
                }
                return  View(Students);


            }

        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Student student = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = await client.GetAsync($"api/Student/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Student>(jsonResponse);
                }
            }
            return View(student);

        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student student)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    var jsonContent = JsonConvert.SerializeObject(student);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage Res = await client.PostAsync("api/Student", content);
                    if (Res.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Student student = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync($"api/Student/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var response = await Res.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Student>(response);
                }
            }
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student student)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    var jsonContent = JsonConvert.SerializeObject(student);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage Res = await client.PutAsync($"api/Student/{id}", content);
                    if (Res.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: StudentController/Delete/5
        public async  Task<ActionResult> Delete(int id)
        {
            Student student = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync($"api/Student/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var response = await Res.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Student>(response);
                }
            }
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Student student)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    HttpResponseMessage Res = await client.DeleteAsync($"api/Student/{id}");
                    if (Res.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}
