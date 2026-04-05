using StudentsCourseManagement.Application.Students.CreateStudent;
using StudentsCourseManagement.Application.Students.EnrollStudent;
using StudentsCourseManagement.Application.Students.GetAllStudents;
using StudentsCourseManagement.Application.Students.GetStudent;
using StudentsCourseManagement.Application.Students.UnenrollStudentFromCourse;
using StudentsCourseManagement.Application.Students.UpdateStudent;

namespace StudentsCourseManagement.Api.Endpoints;

public static class StudentsEndpoints
{
    public static void MapStudents(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/students");

        // CREATE
        group.MapPost("/", async (
            CreateStudentRequest command,
            CreateStudentHandler handler,
            CancellationToken ct) =>
        {
            var id = await handler.Handle(command, ct);
            return Results.Created($"/students/{id}", id);
        });

        // GET BY ID
        group.MapGet("/{id:guid}", async (
            Guid id,
            GetStudentHandler handler) =>
        {
            var result = await handler.Handle(new GetStudentRequest(id));
            return Results.Ok(result);
        });

        // GET ALL (pagination)
        group.MapGet("/", async (
            int page,
            int pageSize,
            GetAllStudentsHandler handler) =>
        {
            var result = await handler.Handle(
                new GetAllStudentsRequest(page, pageSize));

            return Results.Ok(result);
        });

        // UPDATE
        group.MapPut("/{id:guid}", async (
            Guid id,
            UpdateStudentRequest command,
            UpdateStudentHandler handler,
            CancellationToken ct) =>
        {
            var updatedCommand = command with { Id = id };

            await handler.Handle(updatedCommand, ct);

            return Results.NoContent();
        });

        // // DELETE
        // group.MapDelete("/{id:guid}", async (
        //     Guid id,
        //     DeleteStudentHandler handler,
        //     CancellationToken ct) =>
        // {
        //     await handler.Handle(new DeleteStudentCommand(id), ct);
        //
        //     return Results.NoContent();
        // });

        // ENROLL
        group.MapPost("/{studentId:guid}/courses/{courseId:guid}", async (
            Guid studentId,
            Guid courseId,
            EnrollStudentHandler handler,
            CancellationToken ct) =>
        {
            await handler.Handle(
                new EnrollStudentRequest(studentId, courseId), ct);

            return Results.NoContent();
        });

        // UNENROLL
        group.MapDelete("/{studentId:guid}/courses/{courseId:guid}", async (
            Guid studentId,
            Guid courseId,
            UnenrollStudentHandler handler,
            CancellationToken ct) =>
        {
            await handler.Handle(
                new UnenrollStudentRequest(studentId, courseId), ct);

            return Results.NoContent();
        });
    }
}