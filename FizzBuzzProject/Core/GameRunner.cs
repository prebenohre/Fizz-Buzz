using FizzBuzzProject.Rules;

namespace FizzBuzzProject.Core;

/// <summary>
/// Executes the FizzBuzz game logic using a provided rule engine.
/// </summary>
public class GameRunner(RuleEngine ruleEngine)
{
    /// Runs the game from a start number to an end number, displaying outputs based on the rules.
    public void Run(int start, int end, bool reversed, string description)
    {
        Console.WriteLine($"\n{description}");
        PrintRules();

        int count = Math.Abs(end - start) + 1;

        IEnumerable<int> numbers = Enumerable.Range(Math.Min(start, end), count);

        if (reversed)
        {
            numbers = numbers.Reverse();
        }

        foreach (var i in numbers)
        {
            var result = ruleEngine.ApplyRules(i);
            Console.WriteLine(result);
        }
    }

    private void PrintRules()
    {
        Console.WriteLine("\nApplied Rules:");

        var divisibleRules = ruleEngine.Rules.OfType<DivisibleRule>().ToList();

        foreach (var rule in divisibleRules)
        {
            Console.WriteLine($"- If divisible by {rule.Divisor}, print '{rule.GetReplacement()}'");
        }

        var combinations = GetCombinations(divisibleRules);

        foreach (var combination in combinations)
        {
            var divisors = combination.Select(r => r.Divisor);
            var replacements = combination.Select(r => r.GetReplacement());

            Console.WriteLine(
                $"- If divisible by {string.Join(" and ", divisors)}, print '{string.Concat(replacements)}'");
        }
    }

    /// Generates all combinations of two rules.
    private List<List<DivisibleRule>> GetCombinations(List<DivisibleRule> rules)
    {
        var combinations = new List<List<DivisibleRule>>();

        for (int i = 0; i < rules.Count; i++)
        {
            for (int j = i + 1; j < rules.Count; j++)
            {
                combinations.Add(new List<DivisibleRule> { rules[i], rules[j] });
            }
        }

        return combinations;
    }
}