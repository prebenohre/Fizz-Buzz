using FizzBuzzProject.Core;
using FizzBuzzProject.Interfaces;
using FizzBuzzProject.Rules;

namespace FizzBuzzTests.Core;

/// <summary>
/// Contains unit tests for the <see cref="RuleEngine"/> class.
/// </summary>
public class RuleEngineTests
{
    [Fact]
    public void ApplyRules_NumberMatchesNoRules_ReturnsNumberAsString()
    {
        // Arrange
        var rules = new List<IRule>();
        var ruleEngine = new RuleEngine(rules);
        int number = 7;

        // Act
        var result = ruleEngine.ApplyRules(number);

        // Assert
        Assert.Equal("7", result);
    }

    [Fact]
    public void ApplyRules_NumberMatchesOneRule_ReturnsReplacement()
    {
        // Arrange
        var rule = new DivisibleRule(3, "Fizz");
        var rules = new List<IRule> { rule };
        var ruleEngine = new RuleEngine(rules);
        int number = 9;

        // Act
        var result = ruleEngine.ApplyRules(number);

        // Assert
        Assert.Equal("Fizz", result);
    }

    [Fact]
    public void ApplyRules_NumberMatchesMultipleRules_ReturnsConcatenatedReplacements()
    {
        // Arrange
        var rule1 = new DivisibleRule(3, "Fizz");
        var rule2 = new DivisibleRule(5, "Buzz");
        var rules = new List<IRule> { rule1, rule2 };
        var ruleEngine = new RuleEngine(rules);
        int number = 15;

        // Act
        var result = ruleEngine.ApplyRules(number);

        // Assert
        Assert.Equal("FizzBuzz", result);
    }
}