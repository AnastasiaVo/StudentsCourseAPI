namespace StudentsCourseManagement.Application.Students.UnenrollStudentFromCourse;

public record UnenrollStudentRequest(
    Guid StudentId,
    Guid CourseId
    );