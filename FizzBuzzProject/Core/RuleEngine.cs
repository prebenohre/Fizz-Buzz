using FizzBuzzProject.Interfaces;

namespace FizzBuzzProject.Core;

/// <summary>
/// Processes numbers through a set of rules to determine the appropriate output.
/// </summary>
public class RuleEngine(List<IRule> rules)
{
    public List<IRule> Rules { get; } = rules;

    public string ApplyRules(int number)
    {
        var replacements = Rules
            .Where(rule => rule.IsMatch(number))
            .Select(rule => rule.GetReplacement())
            .ToList();

        if (replacements.Any())
        {
            return string.Concat(replacements);
        }

        return number.ToString();
    }
}