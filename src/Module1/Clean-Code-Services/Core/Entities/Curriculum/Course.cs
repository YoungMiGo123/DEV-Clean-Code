using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Clean_Code_Services.Core.Entities.Course
{
    public class Course
    {
            public int Id { get; set; }
            public int  CreatedBy { get; set; }
            public DateTime CreatedDateTime { get; set; }
            public DateTime ModifiedDateTime { get; set; }
            bool Active { get; set; }
            public string Title { get; set; }
            public ICollection<Section> Sections { get; set; }

    }
}
