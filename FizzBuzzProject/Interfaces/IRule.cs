namespace FizzBuzzProject.Interfaces;
/// <summary>
/// Interface for a rule that can be applied to a number.
/// </summary>
public interface IRule
{
    bool IsMatch(int number);
    string GetReplacement();
}