using StudentsCourseManagementSystem.Enums;
using StudentsCourseManagementSystem.Exceptions;

namespace StudentsCourseManagementSystem.Entities;

public class User
{
    public Guid Id { get; private set; }

    public string Email { get; private set; } = null!;

    public string PasswordHash { get; private set; } = null!;

    public UserRole Role { get; private set; }

    public Guid? StudentId { get; private set; }

    public Student? Student { get; private set; }

    private User()
    {
    } // EF Core

    public User(string email, string passwordHash, UserRole role)
    {
        Id = Guid.NewGuid();
        SetEmail(email);
        SetPasswordHash(passwordHash);
        SetRole(role);
    }

    private void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ValidationException("Email cannot be empty");

        if (!email.Contains('@'))
            throw new DomainException("Invalid email format");

        Email = email;
    }

    private void SetPasswordHash(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ValidationException("Password hash cannot be empty");

        PasswordHash = passwordHash;
    }

    private void SetRole(UserRole role)
    {
        if (!Enum.IsDefined(role))
            throw new ValidationException("Invalid user role");

        Role = role;
    }

    public void LinkStudent(Guid studentId)
    {
        if (Role != UserRole.Student)
            throw new DomainException("Only users with the Student role can be linked to a student");

        if (studentId == Guid.Empty)
            throw new ValidationException("Student id cannot be empty");

        StudentId = studentId;
    }
}
