using CW1_13664.Models;
using CW1_13664.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CW1_13664.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>

        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/Student
        [HttpGet]
        public ActionResult Get()
        {
            var students = _studentRepository.GetStudents();
            return new OkObjectResult(students);
            //return new string[] { "value1", "value2" };

        }


        // GET: api/Product/5
        [HttpGet("{id}")]

        public ActionResult GetById(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            return new OkObjectResult(student);
            //return "value";
        }



        // POST: StudentController/Create
        [HttpPost]

        public ActionResult Post([FromBody] Student student)
        {
            using (var scope = new TransactionScope())
            {
                _studentRepository.InsertStudent(student);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = student.ID }, student);
            }

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Student student)
        {
            if (student != null)
            {
                using (var scope = new TransactionScope())
                {
                    _studentRepository.UpdateStudent(student);
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
            _studentRepository.DeleteStudent(id);
            return new OkResult();

        }

    }
}
