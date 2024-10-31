using CW1_13664.Models;

namespace CW1_13664.Repository
{
    public interface ICourseRepository
    {
        void InsertCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int courseId);
        Course GetCourseById(int Id);
        IEnumerable<Course> GetCourses();
    }
}
