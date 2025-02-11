namespace FizzBuzzProject.Models;

/// <summary>
/// Represents a rule model received from the API.
/// </summary>
/// <remarks>
/// The compiler may throw warnings saying that the setters are never used.
/// This is explicitly true, but the JsonSerializer need setters to deserialize the JSON-data from API to objects.
/// </remarks>
public class ApiRuleModel
{
    public int Number { get; set; }
    public required string Word { get; set; }
}