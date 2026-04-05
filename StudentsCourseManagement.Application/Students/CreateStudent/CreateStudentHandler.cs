using StudentsCourseManagement.Application.Common;
using StudentsCourseManagementSystem.Entities;
using StudentsCourseManagementSystem.Exceptions;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Application.Students.CreateStudent;

public class CreateStudentHandler(
    IStudentRepository studentRepository,
    IUnitOfWork unitOfWork)
{
    private readonly IStudentRepository _studentRepository = studentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<CreateStudentResponse> Handle(CreateStudentRequest request, CancellationToken cancellationToken = default)
    {
        // 1. Check uniqueness (Application-level rule)
        var exists = await _studentRepository.ExistsByEmailAsync(request.Email);
        if (exists)
            throw new ValidationException("Student with this email already exists");

        // 2. Create domain entity
        var student = new Student(
            request.FirstName,
            request.LastName,
            request.Email);

        // 3. Save
        await _studentRepository.AddAsync(student);

        // 4. Commit transaction
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // 5. Return response
        return new CreateStudentResponse(student.Id);
    }
}