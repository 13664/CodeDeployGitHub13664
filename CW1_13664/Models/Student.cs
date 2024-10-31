using System.ComponentModel.DataAnnotations.Schema;

namespace CW1_13664.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [ForeignKey(nameof(Course))]
        public int? CourseId { get; set; }

        public Course? StudentCourse { get; set; } = null!;

    }
}
