using Clean_Code_Services.Core.Entities.User;

namespace Clean_Code_Services.Core.Entities.Video
{
    public class VideoUpload : BaseEntity
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
    }
}
