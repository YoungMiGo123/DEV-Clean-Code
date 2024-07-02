using Ardalis.Result;
using Clean_Code_Services.Features.Playback.Dto;
using MediatR;

namespace Clean_Code_Services.Features.Playback.Queries
{
    public class SongsQuery : IRequest<Result<IEnumerable<SongDto>>>
    {
    }
}
