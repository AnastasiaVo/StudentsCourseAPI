using StudentsCourseManagement.Application.Auth.Common;
using StudentsCourseManagementSystem.Exceptions;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Application.Auth.Login;

public class LoginHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtTokenGenerator jwtTokenGenerator)
{
    public async Task<LoginResponse> Handle(
        LoginRequest request,
        CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByEmailAsync(request.Email);

        if (user is null || !passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            throw new DomainException("Invalid credentials");

        var token = jwtTokenGenerator.GenerateToken(user);

        return new LoginResponse(token.AccessToken, token.ExpiresAtUtc);
    }
}
