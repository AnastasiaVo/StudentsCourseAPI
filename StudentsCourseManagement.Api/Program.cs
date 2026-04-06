using StudentsCourseManagement.Api;
using StudentsCourseManagement.Api.Middleware;
using StudentsCourseManagement.Infrastructure;
using DependencyInjection = StudentsCourseManagement.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Default")!);

DependencyInjection.AddApplication(builder.Services);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();


app.MapEndpoints();

app.Run();