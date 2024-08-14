using Clean_Code_Services.Core.Entities;

namespace Clean_Code_Services.Features.Instructor.Dto
{
    public class CurriculumItem : BaseEntity
    {
        public Guid SectionId { get; set; }
        public Section Section { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }
        public bool Editing { get; set; }
    }
}
