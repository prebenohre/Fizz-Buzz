using FizzBuzzProject.Exceptions;

namespace FizzBuzzProject.Rules;

/// <summary>
/// A rule that checks if a number is divisible by a specified divisor.
/// </summary>
public class DivisibleRule : BaseRule
{
    public int Divisor { get; }

    private readonly string _replacement;

    public DivisibleRule(int divisor, string replacement)
    {
        if (divisor == 0 && string.IsNullOrEmpty(replacement))
            throw new RuleValidationException("\nDivisor and replacement cannot both be empty.");
        if (divisor == 0)
            throw new RuleValidationException("\nDivisor cannot be zero.");
        if (string.IsNullOrEmpty(replacement))
            throw new RuleValidationException("\nReplacement cannot be empty.");


        Divisor = divisor;
        _replacement = replacement;
    }

    public override bool IsMatch(int number)
    {
        return number % Divisor == 0;
    }

    public override string GetReplacement()
    {
        return _replacement;
    }
}