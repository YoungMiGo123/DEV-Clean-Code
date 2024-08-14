

using BooksApi.Infrastructure.Repositories;
using Clean_Code_Services.Core.Entities.Course;
using Clean_Code_Services.Features.Instructor.Command;
using Clean_Code_Services.Features.Instructor.Dto;
using Clean_Code_Services.Infrastructure.Contexts;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data.Common;


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
                    Sections = new List<Dto.Section>()

                };
                _courseRepository.CreateAsync(course);

                if (command.Sections != null)
                {

                    foreach (var commandSection in command.Sections)
                    {
                        var section = new Dto.Section
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
                                CreatedBy = command.userId,  // how to deal with user Id
                                ModifiedBy = command.userId,
                                Title = commandCurriculumItem.Title,
                                Type = commandCurriculumItem.Type,
                                Material = commandCurriculumItem.Material,
                                Editing = commandCurriculumItem.Editing,

                            }).ToList()
                        };


                        section.CurriculumItem = section.CurriculumItem?.Select(commandCurriculumItem => new CurriculumItem
                        {
                            SectionId = section.Id,
                            CreatedDateTime = DateTime.Now,
                            ModifiedDateTime = DateTime.Now,
                            CreatedBy = command.userId,  // how to deal with user Id
                            ModifiedBy = command.userId,
                            Title = commandCurriculumItem.Title,
                            Type = commandCurriculumItem.Type,
                            Material = commandCurriculumItem.Material,
                            Editing = commandCurriculumItem.Editing,


                        }).ToList() ?? new List<CurriculumItem>();

                        course.Sections.Add(section);
                        _courseRepository.Save();
                    }
                }
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


