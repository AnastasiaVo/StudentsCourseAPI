using Microsoft.EntityFrameworkCore;
using StudentsCourseManagement.Infrastructure.Persistence;
using StudentsCourseManagementSystem.Entities;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task AddAsync(User user)
    {
        await context.Users.AddAsync(user);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<bool> ExistsByStudentIdAsync(Guid studentId)
    {
        return await context.Users.AnyAsync(u => u.StudentId == studentId);
    }
}
