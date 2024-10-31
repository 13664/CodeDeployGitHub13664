using CW1_13664.DBContext;
using CW1_13664.Models;
using Microsoft.EntityFrameworkCore;

namespace CW1_13664.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentContext _dbContext;
        public CourseRepository(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteCourse(int courseId)
        {
            var course = _dbContext.Courses.Find(courseId);
            _dbContext.Courses.Remove(course);
            Save();
        }

        public Course GetCourseById(int Id)
        {
            var course = _dbContext.Courses.Find(Id);
            return course;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _dbContext.Courses.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void InsertCourse(Course course)
        {
            _dbContext.Courses.Add(course);
            Save();
        }

        public void UpdateCourse(Course course)
        {
            _dbContext.Entry(course).State =
           EntityState.Modified;
            Save();
        }
    }
}
