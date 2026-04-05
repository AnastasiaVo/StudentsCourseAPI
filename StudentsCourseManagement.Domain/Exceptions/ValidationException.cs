namespace StudentsCourseManagementSystem.Exceptions;

public class ValidationException(string message) : DomainException(message);