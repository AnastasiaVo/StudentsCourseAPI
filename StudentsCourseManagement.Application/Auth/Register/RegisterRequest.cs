namespace StudentsCourseManagement.Application.Auth.Register;

public record RegisterRequest(
    string Email,
    string Password,
    string Role,
    Guid? StudentId);
