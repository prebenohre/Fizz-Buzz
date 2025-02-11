namespace FizzBuzzProject.Exceptions;

/// <summary>
/// Represents errors that occur during API requests.
/// </summary>
public class ApiException(string message, Exception innerException) : BaseException(message, innerException);