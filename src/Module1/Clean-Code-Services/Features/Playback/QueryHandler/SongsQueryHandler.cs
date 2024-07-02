using Ardalis.Result;
using Clean_Code_Services.Features.Application.Services.Upload;
using Clean_Code_Services.Features.Playback.Dto;
using Clean_Code_Services.Features.Playback.Queries;
using MediatR;

namespace Clean_Code_Services.Features.Playback.QueryHandler
{
    public class SongsQueryHandler(IAzureStorageService _azureStorageService) : IRequestHandler<SongsQuery, Result<IEnumerable<SongDto>>>
    {
        public async Task<Result<IEnumerable<SongDto>>> Handle(SongsQuery request, CancellationToken cancellationToken)
        {
            var songs = await _azureStorageService.GetSongs();
            return Result<IEnumerable<SongDto>>.Success(songs.Select(song => new SongDto
            {
                Name = song.Name,
                Url = song.Url
            }));
        }
    }
}
