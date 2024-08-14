using Clean_Code_Services.Core.Entities.Course;
using Clean_Code_Services.Core.Entities.Curriculum;

namespace Clean_Code_Services.Features.Instructor.Command
{
    public class CreateSectionCommand
    {
        public Guid SectionId {  get; set; } 
        public Guid CourseId { get; set; } 
        public string Title { get; set; }  
        public ICollection<CreateCurriculumItemCommand> CurriculumItems { get; set; }
    }
}
