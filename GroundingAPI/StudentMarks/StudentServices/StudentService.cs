using Microsoft.EntityFrameworkCore;
namespace StudentMarks;

public class StudentService
{
    private readonly StudentDbContext _context; //its a private field/property of type StudentDbContext used to interact with db

    public StudentService(StudentDbContext context) //constructor that takes StudentDbContext as a parameter
    {
        _context = context; //assigning the context to the private field
    }

    // public Student CreateStudent(int Id, string name, int eng, int mat, int sci) //method to create a student
    // {
    //     var student = new Student(Id, name, eng, mat, sci); //creating a new student object
    //     _context.Students.Add(student); //adding the student to the db
    //     _context.SaveChanges(); //saving the changes
    //     return student; //returning the student
    // }

    public async Task<Student> InsertStudentAsync(Student student) //method to insert a student asynchronously
    {
        _context.Students.Add(student); //adding the student to the db
        await _context.SaveChangesAsync(); //saving the changes asynchronously
        return student; //returning the student
    }

    // public Student? GetStudent(int id) //method to get a student by id
    // {
    //     return _context.Students.Find(id); //returning the student with the given id
    // }

    public async Task<Student?> GetStudentAsync(int id) //method to get a student by id asynchronously
    {
        return await _context.Students.FindAsync(id); //returning the student with the given id asynchronously
    }

    // public IEnumerable<Student> GetStudents() //method to get all students
    // {
    //     return _context.Students.ToList(); //returning all students
    // }


    public async Task<List<Student>> GetStudentsAsync() //method to get all students asynchronously
    {
        var list = _context.Students.ToListAsync(); //getting all students asynchronously
        return await list; //returning all students
    }

    // public void UpdateStudent(Student student) //method to update a student
    // {
    //     _context.Entry(student).State = EntityState.Modified; //setting the state of the student to modified
    //     _context.SaveChanges(); //saving the changes
    // }

    public async Task UpdateStudentAsync(Student student) //method to update a student asynchronously
    {
        _context.Entry(student).State = EntityState.Modified; //setting the state of the student to modified
        await _context.SaveChangesAsync(); //saving the changes asynchronously
    }

    // public void DeleteStudent(int id) //method to delete a student by id
    public void DeleteStudent(int id) //method to delete a student by id
    {
        var student = _context.Students.Find(id); //finding the student with the given id
        _context.Students.Remove(student); //removing the student
        _context.SaveChanges(); //saving the changes
    }

    

}
