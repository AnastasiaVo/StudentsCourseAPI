namespace StudentsCourseManagement.Application.Students.EnrollStudent;

public record EnrollStudentRequest(
    Guid StudentId,
    Guid CourseId
    );