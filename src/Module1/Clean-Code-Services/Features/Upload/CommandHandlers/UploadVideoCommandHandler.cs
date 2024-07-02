using Ardalis.Result;
using BooksApi.Infrastructure.Repositories;
using Clean_Code_Services.Core.Entities.Video;
using Clean_Code_Services.Features.Application.Services.Upload;
using Clean_Code_Services.Features.Upload.Command;
using Clean_Code_Services.Features.Upload.Dto;
using MediatR;

namespace Clean_Code_Services.Features.Upload.CommandHandlers
{
    public class UploadVideoCommandHandler(IUserUploadRepository _uploadRepository, IAzureStorageService _azureStorageService) : IRequestHandler<UploadVideoCommand, Result<UploadVideoResponseDto>>
    {
        public async Task<Result<UploadVideoResponseDto>> Handle(UploadVideoCommand request, CancellationToken cancellationToken)
        {
            var fileUploadRequest = new UploadFileRequest($"{request.FileName}|{request.UserId}", request.Extension, request.VideoFileBase64);

            var url = await _azureStorageService.UploadAsync(fileUploadRequest);

            var upload = new VideoUpload
            {
                Title = request.Title,
                CreatedBy = request.UserId,
                CreatedDateTime = DateTime.UtcNow,
                Description = request.Description,
                Tags = request.Tags,
                Url = url
            };

            var response = await _uploadRepository.CreateAsync(upload);

            return Result.Success(new UploadVideoResponseDto
            {
                Id = response.Id,
                UserId = request.UserId.ToString(),
                VideoUrl = url,
            });
        }
    }
}
