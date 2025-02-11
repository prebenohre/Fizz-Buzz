namespace FizzBuzzProject.Exceptions;

/// <summary>
/// Serves as the base class for custom exceptions in the FizzBuzz project.
/// </summary>
public class BaseException : Exception
{
    protected BaseException(string message)
        : base(message)
    {
    }

    protected BaseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}