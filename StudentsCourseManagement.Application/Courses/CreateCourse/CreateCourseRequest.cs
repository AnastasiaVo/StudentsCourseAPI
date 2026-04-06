using StudentsCourseManagementSystem.Enums;

namespace StudentsCourseManagement.Application.Courses.CreateCourse;

public record CreateCourseRequest(string Title, string Level, string? Description);