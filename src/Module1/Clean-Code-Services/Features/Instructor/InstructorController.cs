using BooksApi.Infrastructure.Repositories;
using Clean_Code_Services.Features.Instructor.Command;
using Clean_Code_Services.Features.Instructor.CommandHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var serializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            if (command == null) { throw new ArgumentNullException(nameof(command), "Command cannot be null."); }
            var result = JsonConvert.SerializeObject(await _courseHandler.HandleAsync(command), serializerSettings) ;
            return Ok(result);

        }

    }
}
