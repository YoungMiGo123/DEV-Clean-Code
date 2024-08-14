using Clean_Code_Services.Core.Entities;

namespace Clean_Code_Services.Features.Instructor.Dto
{
    public class Section : BaseEntity
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public Course Course { get; set; }
        public ICollection<CurriculumItem> CurriculumItem { get; set; }

       
    }
}
