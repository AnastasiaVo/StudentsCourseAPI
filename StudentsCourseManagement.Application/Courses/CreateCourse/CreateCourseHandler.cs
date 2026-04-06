using StudentsCourseManagement.Application.Common;
using StudentsCourseManagementSystem.Entities;
using StudentsCourseManagementSystem.Enums;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Application.Courses.CreateCourse;

public class CreateCourseHandler(ICourseRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Guid> Handle(CreateCourseRequest request)
    {
        var course = new Course(
            request.Title, 
            Enum.Parse<CourseLevel>(request.Level, true), 
            request?.Description);

        await repository.AddAsync(course);
        await unitOfWork.SaveChangesAsync();

        return course.Id;
    }
}