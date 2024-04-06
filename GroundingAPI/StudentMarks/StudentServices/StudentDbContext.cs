using Microsoft.EntityFrameworkCore;
namespace StudentMarks;

public class StudentDbContext: DbContext
{
    public DbSet<Student> Students { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Student.db");
        //optionsBuilder.UseInMemoryDatabase("Student");
    }
}
// Path: StudentServices/StudentService.cs
