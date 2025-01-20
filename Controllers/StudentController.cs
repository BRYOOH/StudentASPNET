
using Microsoft.AspNetCore.Mvc;

namespace StudentAPI.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController:ControllerBase
    {
        static private List<Student> students= new List<Student>{
            new Student{
                Id=1,
                StudentName="Brian Muriuki",
                AdminNo="SC201/0656/2018"
            },
            new Student{
                Id=2,
                StudentName="Geoffery",
                AdminNo="KIM/49381/18"
            },
            new Student{
                Id=3,
                StudentName="Brian Muriuki",
                AdminNo="SC201/0656/2018"
            },
        };

        [HttpGet]
        public ActionResult <List<Student>> GetAllStudents(){
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id){
            
            var student= students.FirstOrDefault(x=>x.Id==id);
            if(student==null)
            return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student newStudent){
            if(newStudent==null)
            return BadRequest();

            newStudent.Id = students.Max(x=>x.Id) + 1;
            students.Add(newStudent);
            return CreatedAtAction(nameof(GetStudentById),new {id=newStudent.Id}, newStudent);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatedStudent(Student updateStudent, int id){
            var student = students.FirstOrDefault(x=>x.Id==id);
            if(student==null)
            return NotFound();

            student.AdminNo = updateStudent.AdminNo;
            student.StudentName= updateStudent.StudentName;

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent (int id){
            var student = students.FirstOrDefault(x=>x.Id==id);
            if(student==null)
            return NotFound();

            students.Remove(student);
            return NoContent();
        }

    }
}