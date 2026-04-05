using StudentsCourseManagementSystem.Interfaces;

namespace StudentsCourseManagement.Application.Students.GetAllStudents;

public class GetAllStudentsHandler(IStudentRepository repository)
{
    public async Task<GetAllStudentsResponse> Handle(GetAllStudentsRequest request)
    {
        var (students, totalCount) =
            await repository.GetAllStudentsAsync(request.Page, request.PageSize);

        var result = students.Select(s => new StudentListItem(
            s.Id,
            s.FirstName,
            s.LastName,
            s.Email
        )).ToList();

        return new GetAllStudentsResponse(result, totalCount);
    }
}