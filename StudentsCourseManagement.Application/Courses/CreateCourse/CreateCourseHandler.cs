using StudentsCourseManagement.Application.Common;
using StudentsCourseManagementSystem.Entities;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Application.Courses.CreateCourse;

public class CreateCourseHandler(ICourseRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Guid> Handle(CreateCourseRequest request)
    {
        var course = new Course(request.Title, request.Level, request?.Description);

        await repository.AddAsync(course);
        await unitOfWork.SaveChangesAsync();

        return course.Id;
    }
}