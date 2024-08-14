namespace Clean_Code_Services.Features.Instructor.Command
{
    public class CreateCourseCommand
    {
        public Guid CourseId { get; set; }
        public Guid userId { get; set; }
        public string Title { get; set; } 
        public ICollection<CreateSectionCommand> Sections { get; set; }

    }
}
