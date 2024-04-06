using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http.HttpResults;
namespace StudentMarks;


[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentService _studentService; // its a private field/property of type StudentService used to interact with the business logic related to students

    public StudentsController(StudentService studentService) //constructor that takes StudentService as a parameter
    {
        _studentService = studentService; //assigning the service to the private field
    }

    [HttpGet("{id}")] //attribute to specify the route for the action

    public ActionResult<Student> GetStudent(int id) //method to get a student by id
    {
        var student = _studentService.GetStudentAsync(id); //getting the student asynchronously
        if (student == null) //if the student is not found
        {
            return NotFound(); //returning a 404 Not Found response
        }
        return Ok(student); //returning a 200 OK response with the student
    }

    [HttpGet] //attribute to get all student records
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents() //method to get all students
    {
        var students = await _studentService.GetStudentsAsync(); //await the asynchronous method call
        return students.ToList(); //returning all students as a list
    }

    [HttpPost] //attribute to create a new student record

    public async Task<ActionResult<Student>> CreateStudent([FromBody] Student student) //method to create a student
    {
        var newStudent = await _studentService.InsertStudentAsync(student); //await the asynchronous method call
        return CreatedAtAction(nameof(CreateStudent), new { id = newStudent.Id }, newStudent); //returning a 201 Created response with the new student
    }

    [HttpPatch("{id}")] //attribute to update a student record
    public async Task<ActionResult<Student>> UpdateStudent(int id, [FromBody] Student student) //method to update a student
    {
        if (id != student.Id) //if the id in the URL does not match the id in the request body
        {
            return BadRequest(); //returning a 400 Bad Request response
        }
        try
        {
            await _studentService.UpdateStudentAsync(student); //await the asynchronous method call
            return Ok(student); //returning a 200 OK response with the updated student
        }
        catch (Exception e) //catching any exceptions
        {
            return BadRequest(new { Error = e.Message }); //returning a 400 Bad Request response with the error message
        }
    }

    [HttpDelete("{id}")] //attribute to delete a student record

    // public async Task<ActionResult<Student>> DeleteStudent(int id) //method to delete a student
    // {
    //     var student = await _studentService.GetStudentAsync(id); //await the asynchronous method call
    //     if (student == null) //if the student is not found
    //     {
    //         return NotFound(); //returning a 404 Not Found response
    //     }
    //     await _studentService.DeleteStudentAsync(id); //await the asynchronous method call
    //     return Ok(student); //returning a 200 OK response with the deleted student
    // }

    public ActionResult<Student> DeleteStudent(int id)
    {
        _studentService.DeleteStudent(id);
        return Ok();
    }

}
