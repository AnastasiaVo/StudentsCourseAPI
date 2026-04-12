using StudentsCourseManagementSystem.Entities;

namespace StudentsCourseManagementSystem.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByStudentIdAsync(Guid studentId);
}
