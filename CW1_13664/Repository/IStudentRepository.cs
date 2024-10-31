using CW1_13664.Models;

namespace CW1_13664.Repository
{
    public interface IStudentRepository
    {
        void InsertStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int studentId);
        Student GetStudentById(int Id);
        IEnumerable<Student> GetStudents();
    }
}
