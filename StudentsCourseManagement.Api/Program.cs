using StudentsCourseManagement.Api;
using StudentsCourseManagement.Api.Middleware;
using StudentsCourseManagement.Infrastructure;
using DependencyInjection = StudentsCourseManagement.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
DependencyInjection.AddApplication(builder.Services);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

app.Run();
