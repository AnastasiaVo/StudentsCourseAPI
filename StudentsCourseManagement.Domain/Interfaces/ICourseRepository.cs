using StudentsCourseManagementSystem.Entities;

namespace StudentsCourseManagementSystem.Interfaces;

public interface ICourseRepository
{
    Task AddAsync(Course course);
    Task<Course?> GetByIdAsync(Guid id);
    Task<(List<Course>, int)> GetAllCoursesAsync(int page, int pageSize);
}