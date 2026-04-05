namespace StudentsCourseManagement.Application.Students.CreateStudent;

public record CreateStudentRequest(
    string FirstName,
    string LastName,
    string Email
    );