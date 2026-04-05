using StudentsCourseManagementSystem.Enums;

namespace StudentsCourseManagement.Application.Courses.GetAllCourses;

public record GetAllCoursesResponse(
    List<CourseListItem> Courses,
    int TotalCount);
    
public record CourseListItem(
    Guid Id,
    string Title,
    CourseLevel Level, 
    string Description
);   