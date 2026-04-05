namespace StudentsCourseManagement.Application.Students.GetStudent;

public record GetStudentResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    List<CourseDto> Courses
    );