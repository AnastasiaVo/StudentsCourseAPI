using StudentsCourseManagement.Application.Common;
using StudentsCourseManagementSystem.Exceptions;
using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Application.Students.EnrollStudent;

public class EnrollStudentHandler(
    IStudentRepository studentRepository,
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork)
{
    public async Task Handle(
        EnrollStudentRequest request,
        CancellationToken cancellationToken = default)
    {
        var student = await studentRepository.GetByIdAsync(request.StudentId);
        if (student is null)
            throw new NotFoundException("Student", request.StudentId);

        var course = await courseRepository.GetByIdAsync(request.CourseId);
        if (course is null)
            throw new NotFoundException("Course", request.CourseId);

        student.EnrollToCourse(course);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}