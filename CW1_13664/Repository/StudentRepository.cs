using CW1_13664.DBContext;
using CW1_13664.Models;
using Microsoft.EntityFrameworkCore;

namespace CW1_13664.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _dbContext;
        public StudentRepository(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public void DeleteStudent(int studentId)
        {
            var student = _dbContext.Students.Find(studentId);
            _dbContext.Students.Remove(student);
            Save();
        }

        public Student GetStudentById(int Id)
        {

            var s = _dbContext.Students.Find(Id);
            _dbContext.Entry(s).Reference(s => s.StudentCourse).Load();
            return s;

        }

        public IEnumerable<Student> GetStudents()
        {
            return _dbContext.Students.Include(s => s.StudentCourse).ToList();
        }

        public void InsertStudent(Student student)
        {
            _dbContext.Add(student);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _dbContext.Entry(student).State =
            EntityState.Modified;
            Save();
        }
    }
}
