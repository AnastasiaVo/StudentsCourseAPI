using StudentsCourseManagement.Application.Auth.Login;
using StudentsCourseManagement.Application.Auth.Register;
using LoginRequest = StudentsCourseManagement.Application.Auth.Login.LoginRequest;
using RegisterRequest = StudentsCourseManagement.Application.Auth.Register.RegisterRequest;

namespace StudentsCourseManagement.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuth(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/auth");

        group.MapPost("/register", async (
            RegisterRequest request,
            RegisterHandler handler,
            CancellationToken ct) =>
        {
            var result = await handler.Handle(request, ct);
            return Results.Created($"/auth/users/{result.UserId}", result);
        });

        group.MapPost("/login", async (
            LoginRequest request,
            LoginHandler handler,
            CancellationToken ct) =>
        {
            var result = await handler.Handle(request, ct);
            return Results.Ok(result);
        });
    }
}

