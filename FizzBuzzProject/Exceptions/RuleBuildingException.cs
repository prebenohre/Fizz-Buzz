namespace FizzBuzzProject.Exceptions;

/// <summary>
/// Represents errors that occur during the building of rules.
/// </summary>
public class RuleBuildingException : BaseException
{
    public RuleBuildingException(string message)
        : base(message)
    {
    }

    public RuleBuildingException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}