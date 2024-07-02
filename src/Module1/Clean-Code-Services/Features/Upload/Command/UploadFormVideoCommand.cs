using Ardalis.Result;
using Clean_Code_Services.Features.Upload.Dto;
using MediatR;

namespace Clean_Code_Services.Features.Upload.Command
{
    public class UploadFormVideoCommand : BaseUploadVideoCommand, IRequest<Result<UploadVideoResponseDto>>
    {
        public IFormFile File { get; set; }
    }
}
