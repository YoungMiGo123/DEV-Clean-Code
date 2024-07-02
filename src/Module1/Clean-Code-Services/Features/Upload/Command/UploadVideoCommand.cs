using Ardalis.Result;
using Clean_Code_Services.Features.Upload.Dto;
using MediatR;

namespace Clean_Code_Services.Features.Upload.Command
{
    public class UploadVideoCommand : BaseUploadVideoCommand, IRequest<Result<UploadVideoResponseDto>>
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string VideoFileBase64 { get; set; }

    }
}
