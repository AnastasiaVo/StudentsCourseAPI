using StudentsCourseManagementSystem.Exceptions;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Application.Students.GetStudent;

public class GetStudentHandler(IStudentRepository studentRepository)
{
    public async Task<GetStudentResponse> Handle(
        GetStudentRequest request,
        CancellationToken cancellationToken = default)
    {
        var student = await studentRepository.GetByIdAsync(request.Id);

        if (student is null)
            throw new NotFoundException("Student", request.Id);

        var courses = student.Courses
            .Select(c => new CourseDto(
                c.Id,
                c.Title,
                c.Level.ToString()))
            .ToList();

        return new GetStudentResponse(
            student.Id,
            student.FirstName,
            student.LastName,
            student.Email,
            courses
        );
    }
}