using Clean_Code_Services.Features.Application.Common;
using Clean_Code_Services.Features.Auth.Dto;
using Clean_Code_Services.Features.Auth.Query;
using Clean_Code_Services.Features.Upload.Command;
using Clean_Code_Services.Features.Upload.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Code_Services.Features.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ISender _sender) : ControllerBase
    {
        [HttpGet]
        [Route("UserByEmail")]
        [ProducesResponseType<Response<UserDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UserByEmail(UserQuery query)
        {
            var result = await _sender.Send(query);
            var response = Response<UserDto>.Success("Successfully got user", result.Value);
            return Ok(response);
        }
    }
}
