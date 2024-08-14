using Clean_Code_Services.Core.Entities.Course;
using Clean_Code_Services.Core.Entities.Curriculum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Clean_Code_Services.Core.Entities.Course
{
    public class Section : BaseEntity
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public Course Course { get; set; }
        public ICollection<CurriculumItem> CurriculumItems { get; set; }
    }

}

