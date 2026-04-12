using StudentsCourseManagement.Api.Endpoints;

namespace StudentsCourseManagement.Api;

public static class EndpointRegistration
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapAuth();
        app.MapStudents();
        app.MapCourses();
    }
}
