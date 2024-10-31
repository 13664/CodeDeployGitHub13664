using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DSCC_MVC_13664.Controllers
{
    public class CourseController : Controller
    {
        private readonly string Baseurl = "https://localhost:7274/";

        // GET:CourseController
        public async Task<ActionResult> Index()
        {

            List<Course> Courses = new List<Course>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Course");

                if (Res.IsSuccessStatusCode)
                {
                    var StResponse = Res.Content.ReadAsStringAsync().Result;
                    Courses = JsonConvert.DeserializeObject<List<Course>>(StResponse);
                }
                return View(Courses);


            }

        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Course course = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = await client.GetAsync($"api/Course/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    course = JsonConvert.DeserializeObject<Course>(jsonResponse);
                }
            }
            return View(course);

        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Course course)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    var jsonContent = JsonConvert.SerializeObject(course);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage Res = await client.PostAsync("api/Course", content);
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
            Course course = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync($"api/Course/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var response = await Res.Content.ReadAsStringAsync();
                    course = JsonConvert.DeserializeObject<Course>(response);
                }
            }
            return View(course);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Course course)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    var jsonContent = JsonConvert.SerializeObject(course);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage Res = await client.PutAsync($"api/Course/{id}", content);
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
        public async Task<ActionResult> Delete(int id)
        {
            Course course = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync($"api/Course/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var response = await Res.Content.ReadAsStringAsync();
                    course = JsonConvert.DeserializeObject<Course>(response);
                }
            }
            return View(course);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Course course)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    HttpResponseMessage Res = await client.DeleteAsync($"api/Course/{id}");
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
