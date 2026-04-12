using StudentsCourseManagement.Application.Auth.Common;
using StudentsCourseManagement.Application.Common;
using StudentsCourseManagementSystem.Entities;
using StudentsCourseManagementSystem.Enums;
using StudentsCourseManagementSystem.Exceptions;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Application.Auth.Register;

public class RegisterHandler(
    IUserRepository userRepository,
    IStudentRepository studentRepository,
    IPasswordHasher passwordHasher,
    IUnitOfWork unitOfWork)
{
    public async Task<RegisterResponse> Handle(
        RegisterRequest request,
        CancellationToken cancellationToken = default)
    {
        if (await userRepository.ExistsByEmailAsync(request.Email))
            throw new DomainException("User with this email already exists");

        if (!Enum.TryParse<UserRole>(request.Role, true, out var role) || !Enum.IsDefined(role))
            throw new ValidationException("Invalid user role");

        if (role == UserRole.Student)
        {
            if (request.StudentId is null)
                throw new ValidationException("Student id is required for users with the Student role");

            var student = await studentRepository.GetByIdAsync(request.StudentId.Value);
            if (student is null)
                throw new NotFoundException("Student", request.StudentId.Value);

            if (await userRepository.ExistsByStudentIdAsync(request.StudentId.Value))
                throw new DomainException("This student already has a user account");
        }
        else if (request.StudentId is not null)
        {
            throw new ValidationException("Student id can only be provided for users with the Student role");
        }

        var user = new User(
            request.Email,
            passwordHasher.HashPassword(request.Password),
            role);

        if (request.StudentId is not null)
            user.LinkStudent(request.StudentId.Value);

        await userRepository.AddAsync(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new RegisterResponse(user.Id, user.Email, user.Role.ToString());
    }
}
