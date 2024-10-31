using CW1_13664.Models;
using Microsoft.EntityFrameworkCore;

namespace CW1_13664.DBContext
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
