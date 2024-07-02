using Clean_Code_Services.Features.Application.Common;
using Clean_Code_Services.Features.Playback.Dto;
using Clean_Code_Services.Features.Playback.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Code_Services.Features.Playback
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaybackController(ISender _sender) : ControllerBase
    {
        [HttpGet]
        [Route("Songs")]
        [ProducesResponseType<Response<IEnumerable<SongDto>>>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Songs()
        {
            var result = await _sender.Send(new SongsQuery());
            var response = Response<IEnumerable<SongDto>>.Success("Got songs successfully", result.Value);
            return Ok(response);
        }


        [HttpGet]
        [Route("UserVideoUploads")]
        [ProducesResponseType<Response<IEnumerable<UserVideoUploadDto>>>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UserVideoUploads(UserUploadQuery query)
        {
            var result = await _sender.Send(query);
            var response = Response<IEnumerable<UserVideoUploadDto>>.Success("Got user uploads successfully", result.Value);
            return Ok(response);
        }
    }
}
