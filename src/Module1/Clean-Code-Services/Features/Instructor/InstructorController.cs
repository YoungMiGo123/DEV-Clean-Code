using BooksApi.Infrastructure.Repositories;
using Clean_Code_Services.Features.Instructor.Command;
using Clean_Code_Services.Features.Instructor.CommandHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Code_Services.Features.Instructor
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        

        private readonly CreateCourseCommandHandler _courseHandler;
        public InstructorController(CreateCourseCommandHandler courseHandler)
        {
            _courseHandler = courseHandler;
        }

        [HttpPost]
        [Route(nameof(CreateCourse))]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            if (command == null) { throw new ArgumentNullException(nameof(command), "Command cannot be null."); }
            return (IActionResult)_courseHandler.HandleAsync(command);

        }

    }
}
