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
        // 1. Load student
        var student = await studentRepository.GetByIdAsync(request.StudentId);
        if (student is null)
            throw new NotFoundException("Student", request.StudentId);

        // 2. Load course
        var course = await courseRepository.GetByIdAsync(request.CourseId);
        if (course is null)
            throw new NotFoundException("Course", request.CourseId);

        // 3. Domain logic
        student.EnrollToCourse(course);

        // 4. Save changes
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}