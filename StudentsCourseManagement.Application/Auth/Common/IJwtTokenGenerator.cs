using StudentsCourseManagementSystem.Entities;

namespace StudentsCourseManagement.Application.Auth.Common;

public interface IJwtTokenGenerator
{
    JwtTokenResult GenerateToken(User user);
}
