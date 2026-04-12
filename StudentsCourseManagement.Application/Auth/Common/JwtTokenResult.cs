namespace StudentsCourseManagement.Application.Auth.Common;

public record JwtTokenResult(string AccessToken, DateTime ExpiresAtUtc);
