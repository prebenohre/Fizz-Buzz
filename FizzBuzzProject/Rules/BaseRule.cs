using FizzBuzzProject.Interfaces;

namespace FizzBuzzProject.Rules;

/// <summary>
/// Serves as the base class for all rules in the FizzBuzz game.
/// </summary>
public abstract class BaseRule : IRule
{
    public abstract bool IsMatch(int number);
    public abstract string GetReplacement();
}