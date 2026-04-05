using StudentsCourseManagementSystem.Exceptions;

namespace StudentsCourseManagementSystem.Entities;

public class Student
{
    public Guid Id { get; private set; }
    
    public string FirstName { get; private set; }
    
    public string LastName { get; private set; }
    
    public string Email { get; private set; }

    private readonly List<Course> _courses = new();
    public IReadOnlyCollection<Course> Courses => _courses.AsReadOnly();
    
    public Student(string firstName, string lastName, string email)
    {
        Id = Guid.NewGuid();

        SetName(firstName, lastName);
        SetEmail(email);
    }


    private void SetName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ValidationException("First name cannot be empty");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ValidationException("Last name cannot be empty");

        FirstName = firstName;
        LastName = lastName;
    }

    private void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ValidationException("Email cannot be empty");

        if (!email.Contains('@'))
            throw new DomainException("Invalid email format");

        Email = email;
    }

    public void EnrollToCourse(Course course)
    {
        if (course is null)
            throw new ValidationException("Course cannot be null");

        if (_courses.Any(c => c.Id == course.Id))
            throw new DomainException("Student already enrolled in this course");

        _courses.Add(course);
        course.AttachStudent(this);
    }
    
    public void UnenrollFromCourse(Course course)
    {
        if (_courses.All(c => c.Id != course.Id))
            throw new DomainException("Student is not enrolled in this course");

        _courses.RemoveAll(c => c.Id == course.Id);
    }
    
    public void Update(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}