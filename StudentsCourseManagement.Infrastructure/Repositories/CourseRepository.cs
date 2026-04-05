using Microsoft.EntityFrameworkCore;
using StudentsCourseManagement.Infrastructure.Persistence;
using StudentsCourseManagementSystem.Entities;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Infrastructure.Repositories;

public class CourseRepository(AppDbContext context) : ICourseRepository
{
    public async Task AddAsync(Course course)
    {
        await context.Courses.AddAsync(course);
    }

    public async Task<Course?> GetByIdAsync(Guid id)
    {
        return await context.Courses
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var course = await context.Courses.FindAsync(id);
        if (course != null)
            context.Courses.Remove(course);
    }

    public async Task<(List<Course>, int)> GetAllCoursesAsync(int page, int pageSize)
    {
        var query = context.Courses.AsQueryable();

        var totalCount = await query.CountAsync();

        var items = await query
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}