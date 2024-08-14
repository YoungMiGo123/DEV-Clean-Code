using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Clean_Code_Services.Core.Entities.Course
{
    public class Course : BaseEntity
    {
            public string Title { get; set; }
            public ICollection<Section> Sections { get; set; }

    }
}
