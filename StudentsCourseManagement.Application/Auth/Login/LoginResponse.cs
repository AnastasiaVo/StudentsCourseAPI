namespace StudentsCourseManagement.Application.Auth.Login;

public record LoginResponse(string AccessToken, DateTime ExpiresAtUtc);
