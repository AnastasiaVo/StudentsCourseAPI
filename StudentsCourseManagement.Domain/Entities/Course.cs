using StudentsCourseManagementSystem.Enums;
using StudentsCourseManagementSystem.Exceptions;

namespace StudentsCourseManagementSystem.Entities;

public class Course
{
    public Guid Id { get; private set; }
    
    public string Title { get; private set; }
    
    public string? Description { get; private set; }
    
    public CourseLevel Level { get; private set; }
    
    private readonly List<Student> _students = [];
    public IReadOnlyCollection<Student> Students => _students.AsReadOnly();
    
    public Course(string title, CourseLevel level, string? description = null)
    {
        Id = Guid.NewGuid();
        SetTitle(title);
        SetLevel(level);
        SetDescription(description);
    }

    void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ValidationException("Course title cannot be empty");

        Title = title;
    }

    void SetDescription(string? description)
    {
        Description = description;
    }

    private void SetLevel(CourseLevel level)
    {
        if (!Enum.IsDefined(level))
            throw new ValidationException("Invalid course level");

        Level = level;
    }
    
    internal void AttachStudent(Student student)
    {
        if (student is null)
            throw new ValidationException("Student cannot be null");

        if (_students.Any(s => s.Id == student.Id))
            return;

        _students.Add(student);
    }
}
