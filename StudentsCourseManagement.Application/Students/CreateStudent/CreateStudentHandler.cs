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
        var exists = await _studentRepository.ExistsByEmailAsync(request.Email);
        if (exists)
            throw new ValidationException("Student with this email already exists");

        var student = new Student(
            request.FirstName,
            request.LastName,
            request.Email);

        await _studentRepository.AddAsync(student);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateStudentResponse(student.Id);
    }
}