using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppApi.Models;

namespace WebAppApi.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {  
        public static List<Student> Students = new List<Student>()
        {
             new Student(){StudentId=10, Name="EJLAL",level="1"},
                new Student(){StudentId=20, Name="OLA",level="1"},
        };

        
        [HttpGet]
        public List<Student> GetAll()
        {
            return Students;
        }

        [HttpGet ("{Id}")]
        public IActionResult GetStudentById(int Id)
        {
            var CurStudent = Students.Where(x => x.StudentId == Id).FirstOrDefault();
            if (CurStudent == null)
            {
                return NotFound();
            }
            return Ok (CurStudent);
                
        }
    }

}
