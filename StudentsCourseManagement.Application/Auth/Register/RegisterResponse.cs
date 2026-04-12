namespace StudentsCourseManagement.Application.Auth.Register;

public record RegisterResponse(Guid UserId, string Email, string Role);
