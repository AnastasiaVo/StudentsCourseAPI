using StudentsCourseManagement.Application.Common;
using StudentsCourseManagementSystem.Exceptions;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Application.Students.UpdateStudent;

public class UpdateStudentHandler(IStudentRepository repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(UpdateStudentRequest request, CancellationToken cancellationToken = default)
    {
        var student = await repository.GetByIdAsync(request.Id);
        
        if(student is null)
            throw new NotFoundException("Student", request.Id);
        
        student.Update(request.FirstName, request.LastName, request.Email);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}