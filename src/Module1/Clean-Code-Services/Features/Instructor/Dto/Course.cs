
using Clean_Code_Services.Core.Entities;
using Clean_Code_Services.Features.Instructor.Dto;

public class Course : BaseEntity
{
    public string Title { get; set; }
    public ICollection<Section> Sections { get; set; }
}


