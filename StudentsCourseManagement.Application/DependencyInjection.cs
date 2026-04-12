using Microsoft.Extensions.DependencyInjection;
using StudentsCourseManagement.Application.Auth.Login;
using StudentsCourseManagement.Application.Auth.Register;
using StudentsCourseManagement.Application.Courses.CreateCourse;
using StudentsCourseManagement.Application.Courses.GetAllCourses;
using StudentsCourseManagement.Application.Courses.GetCourse;
using StudentsCourseManagement.Application.Students.CreateStudent;
using StudentsCourseManagement.Application.Students.EnrollStudent;
using StudentsCourseManagement.Application.Students.GetAllStudents;
using StudentsCourseManagement.Application.Students.GetStudent;
using StudentsCourseManagement.Application.Students.UnenrollStudentFromCourse;
using StudentsCourseManagement.Application.Students.UpdateStudent;

namespace StudentsCourseManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Auth handlers
        services.AddScoped<RegisterHandler>();
        services.AddScoped<LoginHandler>();

        // Student handlers
        services.AddScoped<CreateStudentHandler>();
        services.AddScoped<GetStudentHandler>();
        services.AddScoped<GetAllStudentsHandler>();
        services.AddScoped<UpdateStudentHandler>();
        
        // services.AddScoped<DeleteStudentHandler>();
        services.AddScoped<EnrollStudentHandler>();
        services.AddScoped<UnenrollStudentHandler>();

        // Course handlers
        services.AddScoped<CreateCourseHandler>();
        services.AddScoped<GetCourseHandler>();
        services.AddScoped<GetAllCoursesHandler>();
        // services.AddScoped<UpdateCourseHandler>();
        // services.AddScoped<DeleteCourseHandler>();

        return services;
    }
}
