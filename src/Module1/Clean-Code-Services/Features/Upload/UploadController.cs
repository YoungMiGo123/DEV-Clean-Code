using Clean_Code_Services.Features.Application.Common;
using Clean_Code_Services.Features.Upload.Command;
using Clean_Code_Services.Features.Upload.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Code_Services.Features.Upload
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController(ISender _sender) : ControllerBase
    {
        [HttpPost]
        [Route("UploadVideo")]
        [ProducesResponseType<Response<UploadVideoResponseDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadVideo(UploadVideoCommand command)
        {
            var result = await _sender.Send(command);
            var response = Response<UploadVideoResponseDto>.Success("Successfully uploaded video", result.Value);
            return Ok(response);
        }

        [HttpPost]
        [Route("UploadFormVideo")]
        [ProducesResponseType<Response<UploadVideoResponseDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFormVideo([FromForm] UploadFormVideoCommand command)
        {
            var result = await _sender.Send(command);
            var response = Response<UploadVideoResponseDto>.Success("Successfully uploaded video", result.Value);
            return Ok(response);
        }
    }
}
