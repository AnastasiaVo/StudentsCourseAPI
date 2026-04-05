namespace StudentsCourseManagement.Application.Students.UpdateStudent;

public record UpdateStudentRequest(
    Guid Id,
    string FirstName,
    string LastName,
    string Email
    );