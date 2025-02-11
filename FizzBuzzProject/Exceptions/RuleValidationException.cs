namespace FizzBuzzProject.Exceptions;

/// <summary>
/// Represents errors that occur during the validation of rules.
/// </summary>
public class RuleValidationException(string message) : BaseException(message);