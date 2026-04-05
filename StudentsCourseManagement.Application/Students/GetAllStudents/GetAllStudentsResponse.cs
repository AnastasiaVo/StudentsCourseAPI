namespace StudentsCourseManagement.Application.Students.GetAllStudents;

public record GetAllStudentsResponse(
    List<StudentListItem> Students,
    int TotalCount);
    
public record StudentListItem(
    Guid Id,
    string FirstName,
    string LastName,
    string Email
);   