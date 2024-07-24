using Clean_Code_Services.Features.Instructor.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Code_Services.Features.Instructor
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {


        [HttpPost("CreateCourse")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {

            throw new NullReferenceException();

        }

    }
}
