
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;

namespace StudentAPI.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController:ControllerBase
    {

        private readonly StudentDbContext _dbContext;

        public StudentController(StudentDbContext dbContext){
            _dbContext = dbContext;
        }
       
        [HttpGet]
        public async Task<ActionResult <List<Student>>> GetAllStudents(){

            return Ok(await _dbContext.Students.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id){
            
            var student= await _dbContext.Students.FindAsync(id);
            if(student==null)
            return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task <ActionResult<Student>> AddStudent(Student newStudent){
            if(newStudent==null)
            return BadRequest();

            _dbContext.Students.Add(newStudent);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentById),new {id=newStudent.Id}, newStudent);
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> UpdatedStudent(Student updateStudent, int id){
            var student = await _dbContext.Students.FindAsync(id);
            if(student==null)
            return NotFound();

            student.AdminNo = updateStudent.AdminNo;
            student.StudentName= updateStudent.StudentName;

            await _dbContext.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent (int id){
            var student = await _dbContext.Students.FindAsync(id);
            if(student==null)
            return NotFound();

             _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}