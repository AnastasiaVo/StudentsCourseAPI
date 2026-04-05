using StudentsCourseManagementSystem.Exceptions;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Application.Courses.GetCourse;

public class GetCourseHandler(ICourseRepository repository)
{
    public async Task<GetCourseResponse> Handle(GetCourseRequest request)
    {
        var course = await repository.GetByIdAsync(request.Id);

        if (course is null)
            throw new NotFoundException("Course", request.Id);

        return new GetCourseResponse(
            course.Id,
            course.Title,
            course.Level.ToString(),
            course.Description ?? string.Empty
        );
    }
}