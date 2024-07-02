using Ardalis.Result;
using Clean_Code_Services.Features.Playback.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Code_Services.Features.Playback.Queries
{
    public class UserUploadQuery : IRequest<Result<IEnumerable<UserVideoUploadDto>>>
    {
        [FromQuery]
        public Guid UserId { get; set; }
        [FromQuery]
        public Guid? VideoUploadId { get; set; }
    }
}
