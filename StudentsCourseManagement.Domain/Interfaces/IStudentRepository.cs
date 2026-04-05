using StudentsCourseManagementSystem.Entities;

namespace StudentsCourseManagementSystem.Interfaces;

public interface IStudentRepository
{
    Task AddAsync(Student student);
    Task<Student?> GetByIdAsync(Guid id);
    Task<bool> ExistsByEmailAsync(string email);
    Task DeleteAsync(Guid id);
    Task<(List<Student> Students, int TotalCount)> GetAllStudentsAsync(int page, int pageSize);
}