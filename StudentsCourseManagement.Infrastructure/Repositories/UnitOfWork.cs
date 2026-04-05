using StudentsCourseManagement.Application.Common;
using StudentsCourseManagement.Infrastructure.Persistence;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Infrastructure.Repositories;

public class UnitOfWork(
    AppDbContext context,
    IStudentRepository studentRepository,
    ICourseRepository courseRepository)
    : IUnitOfWork
{
    public IStudentRepository Students { get; } = studentRepository;
    public ICourseRepository Courses { get; } = courseRepository;

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await context.SaveChangesAsync(ct);
    }
}