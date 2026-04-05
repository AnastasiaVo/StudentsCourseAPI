namespace StudentsCourseManagement.Application.Courses.GetCourse;

public record GetCourseResponse(Guid Id, string Title, string Level, string? Description);