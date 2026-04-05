using StudentsCourseManagement.Application.Courses.CreateCourse;
using StudentsCourseManagement.Application.Courses.GetAllCourses;
using StudentsCourseManagement.Application.Courses.GetCourse;

namespace StudentsCourseManagement.Api.Endpoints;

public static class MapCoursesEndpoints
{
    public static void MapCourses(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/courses");

        // CREATE
        group.MapPost("/", async (
            CreateCourseRequest command,
            CreateCourseHandler handler) =>
        {
            var id = await handler.Handle(command);
            return Results.Created($"/courses/{id}", id);
        });

        // GET BY ID
        group.MapGet("/{id:guid}", async (
            Guid id,
            GetCourseHandler handler) =>
        {
            var result = await handler.Handle(new GetCourseRequest(id));
            return Results.Ok(result);
        });

        // GET ALL
        group.MapGet("/", async (
            int page,
            int pageSize,
            GetAllCoursesHandler handler) =>
        {
            var result = await handler.Handle(
                new GetAllCoursesRequest(page, pageSize));

            return Results.Ok(result);
        });

        // // UPDATE
        // group.MapPut("/{id:guid}", async (
        //     Guid id,
        //     UpdateCourseRequest command,
        //     UpdateCourseHandler handler,
        //     CancellationToken ct) =>
        // {
        //     var updated = command with { Id = id };
        //
        //     await handler.Handle(updated, ct);
        //
        //     return Results.NoContent();
        // });
        //
        // // DELETE
        // group.MapDelete("/{id:guid}", async (
        //     Guid id,
        //     DeleteCourseHandler handler,
        //     CancellationToken ct) =>
        // {
        //     await handler.Handle(new DeleteCourseRequest(id), ct);
        //
        //     return Results.NoContent();
        // });
    }
}