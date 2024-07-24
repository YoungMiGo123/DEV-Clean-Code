using Clean_Code_Services.Core.Entities.Course;
using Clean_Code_Services.Core.Entities.Curriculum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Clean_Code_Services.Core.Entities.Course
{
    public class Section
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string Title { get; set; }
        public Course Course { get; set; }
        public ICollection<CurriculumItem> CurriculumItems { get; set; }
        bool Active { get; set; }
    }

}

