using FizzBuzzProject.Exceptions;
using FizzBuzzProject.Rules;

namespace FizzBuzzTests.Rules;

/// <summary>
/// Contains unit tests for the <see cref="DivisibleRule"/> class.
/// </summary>
public class DivisibleRuleTests
{
    [Theory]
    [InlineData(3, 9, true)]
    [InlineData(3, 10, false)]
    [InlineData(5, 20, true)]
    [InlineData(5, 22, false)]
    public void IsMatch_ReturnsExpectedResult(int divisor, int number, bool expected)
    {
        // Arrange
        var rule = new DivisibleRule(divisor, "Test");

        // Act
        var result = rule.IsMatch(number);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetReplacement_ReturnsExpectedString()
    {
        // Arrange
        var replacement = "Fizz";
        var rule = new DivisibleRule(3, replacement);

        // Act
        var result = rule.GetReplacement();

        // Assert
        Assert.Equal(replacement, result);
    }

    [Fact]
    public void Constructor_ThrowsRuleValidationException_WhenDivisorIsZero()
    {
        // Arrange & Act & Assert
        Assert.Throws<RuleValidationException>(() => new DivisibleRule(0, "Fizz"));
    }

    [Fact]
    public void Constructor_ThrowsRuleValidationException_WhenReplacementIsEmpty()
    {
        // Arrange & Act & Assert
        Assert.Throws<RuleValidationException>(() => new DivisibleRule(3, ""));
    }

}