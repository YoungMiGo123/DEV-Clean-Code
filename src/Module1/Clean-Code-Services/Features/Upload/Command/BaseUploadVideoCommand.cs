namespace Clean_Code_Services.Features.Upload.Command
{
    public class BaseUploadVideoCommand
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
    }
}
