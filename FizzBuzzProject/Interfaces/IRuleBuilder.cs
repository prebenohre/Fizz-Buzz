namespace FizzBuzzProject.Interfaces;

/// <summary>
/// Interface for building a list of rules.
/// </summary>
public interface IRuleBuilder
{
    Task<List<IRule>> BuildRulesAsync();
}