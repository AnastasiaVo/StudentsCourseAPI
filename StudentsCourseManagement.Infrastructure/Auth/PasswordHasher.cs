using Microsoft.AspNetCore.Identity;
using StudentsCourseManagement.Application.Auth.Common;

namespace StudentsCourseManagement.Infrastructure.Auth;

public class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<object> _passwordHasher = new();

    public string HashPassword(string password)
    {
        return string.IsNullOrWhiteSpace(password)
            ? throw new ArgumentException("Password cannot be empty", nameof(password))
            : _passwordHasher.HashPassword(null!, password);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(passwordHash))
            return false;

        var result = _passwordHasher.VerifyHashedPassword(null!, passwordHash, password);

        return result is PasswordVerificationResult.Success or PasswordVerificationResult.SuccessRehashNeeded;
    }
}
