using Ardalis.Result;
using BooksApi.Infrastructure.Repositories;
using Clean_Code_Services.Features.Playback.Dto;
using Clean_Code_Services.Features.Playback.Queries;
using MediatR;

namespace Clean_Code_Services.Features.Playback.QueryHandler
{
    public class UserUploadQueryHandler(IUserUploadRepository _userUploadRepository) : IRequestHandler<UserUploadQuery, Result<IEnumerable<UserVideoUploadDto>>>
    {
        public async Task<Result<IEnumerable<UserVideoUploadDto>>> Handle(UserUploadQuery request, CancellationToken cancellationToken)
        {
            if (request.VideoUploadId.HasValue)
            {
                return _userUploadRepository
                    .GetAll()
                    .Where(x => x.Id == request.VideoUploadId.Value && x.CreatedBy == request.UserId)
                    .Select(x => new UserVideoUploadDto
                    {
                        UserId = request.UserId,
                        VideoId = request.VideoUploadId.Value,
                        VideoUrl = x.Url,
                        VideoDescription = x.Description,
                        VideoTitle = x.Title,
                    })
                    .ToArray();
            }

            return _userUploadRepository
                .GetAll()
                .Where(x => x.CreatedBy == request.UserId)
                .Select(x => new UserVideoUploadDto
                {
                    UserId = request.UserId,
                    VideoId = x.Id,
                    VideoUrl = x.Url,
                    VideoDescription = x.Description,
                    VideoTitle = x.Title,
                })
                .ToArray();
        }
    }
}
