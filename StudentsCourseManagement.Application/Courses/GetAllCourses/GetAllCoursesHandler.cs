using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Application.Courses.GetAllCourses;

public class GetAllCoursesHandler(ICourseRepository repository)
{
    public async Task<GetAllCoursesResponse> Handle(GetAllCoursesRequest request)
    {
        var (courses, totalCount) =
            await repository.GetAllCoursesAsync(request.Page, request.PageSize);

        var result = courses.Select(s => new Courses.GetAllCourses.CourseListItem(
            s.Id,
            s.Title,
            s.Level,
            s.Description ?? string.Empty
            
        )).ToList();

        return new Courses.GetAllCourses.GetAllCoursesResponse(result, totalCount);
    }
}