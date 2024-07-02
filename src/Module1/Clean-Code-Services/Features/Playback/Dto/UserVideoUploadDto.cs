namespace Clean_Code_Services.Features.Playback.Dto
{
    public class UserVideoUploadDto
    {
        public Guid VideoId { get; set; }
        public Guid UserId { get; set; }
        public string VideoUrl { get; set; }
        public string VideoTitle { get; set; }
        public string VideoDescription { get; set; }

    }
}
