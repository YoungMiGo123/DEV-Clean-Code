namespace Clean_Code_Services.Features.Instructor.Command
{
    public class CreateCurriculumItemCommand
    {
        public Guid CurriculumItemId { get; set; }
        public Guid SectionId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }
        public bool Editing { get; set; }
    }
}
