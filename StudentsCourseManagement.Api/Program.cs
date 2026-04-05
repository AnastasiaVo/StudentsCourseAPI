using StudentsCourseManagement.Api;
using StudentsCourseManagement.Api.Middleware;
using StudentsCourseManagement.Infrastructure;
using DependencyInjection = StudentsCourseManagement.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Default")!);

DependencyInjection.AddApplication(builder.Services);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapEndpoints();

app.Run();