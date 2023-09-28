using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAllStudents()
        {
            string[] students = new string[] { "duc", "tuyen", "dat" };
            return Ok(students);
        }

    }
}
