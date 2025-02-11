namespace FizzBuzzProject.Exceptions;

/// <summary>
/// Represents errors in the application's configuration.
/// </summary>
public class ConfigurationException(string message) : BaseException(message);