
using BooksApi.Infrastructure.Repositories;
using Clean_Code_Services.Features.Instructor.Command;
using Clean_Code_Services.Features.Instructor.Dto;
using Microsoft.Extensions.Azure;



namespace Clean_Code_Services.Features.Instructor.CommandHandlers
{
    public class CreateCourseCommandHandler
    {
        private readonly IGenericRepository<Course> _courseRepository;
        public CreateCourseCommandHandler(IGenericRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> HandleAsync(CreateCourseCommand command)
        {

            try
            {
                var course = new Course
                {
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = DateTime.Now,
                    CreatedBy = command.userId,
                    ModifiedBy = command.userId,
                    Title = command.Title,
                    Deactivated = false,
                    Sections =  new List<Section>()

                };

               
                await _courseRepository.CreateAsync(course);


                if (command.Sections != null)
                {

                    foreach (var commandSection in command.Sections)
                    {
                        var section = new Section
                        {
                            Course = course,
                            CreatedDateTime = DateTime.Now,
                            ModifiedDateTime = DateTime.Now,
                            CreatedBy = command.userId,  // how to deal with user Id
                            ModifiedBy = command.userId,
                            Title = commandSection.Title,
                            CourseId = commandSection.CourseId,
                            Deactivated = false,
                            CurriculumItem = commandSection.CurriculumItems?.Select(commandCurriculumItem => new CurriculumItem
                            {

                                CreatedDateTime = DateTime.Now,
                                ModifiedDateTime = DateTime.Now,
                                CreatedBy = command.userId,
                                ModifiedBy = command.userId,
                                Title = commandCurriculumItem.Title,
                                Type = commandCurriculumItem.Type,
                                Material = commandCurriculumItem.Material,
                                Editing = commandCurriculumItem.Editing,
                                SectionId = commandSection.SectionId

                            }).ToList() ?? new List<CurriculumItem>()
                        };
                      
                        course.Sections.Add(section);
                       

                    }
                }
                _courseRepository.Save();
                

                return course;
            }
            catch (Exception ex)
            {
                var errorMessage = $": Something went wrong while trying to create a new schedule.";
                throw;
            }

        }
    }
}


