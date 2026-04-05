using StudentsCourseManagement.Api.Endpoints;

namespace StudentsCourseManagement.Api;

public static class EndpointRegistration
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapStudents();
        app.MapCourses();
    }
}