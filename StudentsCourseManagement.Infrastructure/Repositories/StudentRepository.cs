using Microsoft.EntityFrameworkCore;
using StudentsCourseManagement.Infrastructure.Persistence;
using StudentsCourseManagementSystem.Entities;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Infrastructure.Repositories;

public class StudentRepository(AppDbContext context) : IStudentRepository
{
    public async Task AddAsync(Student student)
    {
        await context.Students.AddAsync(student);
    }

    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await context.Students
            .Include(s => s.Courses)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await context.Students
            .AnyAsync(s => s.Email == email);
    }

    public async Task DeleteAsync(Guid id)
    {
        var student = await context.Students.FindAsync(id);
        if (student != null)
            context.Students.Remove(student);
    }

    public async Task<(List<Student>, int)> GetAllStudentsAsync(int page, int pageSize)
    {
        var query = context.Students.AsQueryable();

        var totalCount = await query.CountAsync();

        var students = await query
            .Include(s => s.Courses)
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (students, totalCount);
    }
}