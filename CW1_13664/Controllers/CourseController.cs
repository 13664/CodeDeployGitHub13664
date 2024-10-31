using CW1_13664.Models;
using CW1_13664.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CW1_13664.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: api/course
        [HttpGet]
        public ActionResult Get()
        {
            var courses = _courseRepository.GetCourses();
            return new OkObjectResult(courses);
            //return new string[] { "value1", "value2" };

        }


        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]

        public ActionResult GetById(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            return new OkObjectResult(course);
            //return "value";
        }



        // POST: courseController/Create
        [HttpPost]

        public ActionResult Post([FromBody] Course course)
        {
            using (var scope = new TransactionScope())
            {
                _courseRepository.InsertCourse(course);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = course.Id }, course);
            }

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Course course)
        {
            if (course != null)
            {
                using (var scope = new TransactionScope())
                {
                    _courseRepository.UpdateCourse(course);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseRepository.DeleteCourse(id);
            return new OkResult();

        }

    }
}
