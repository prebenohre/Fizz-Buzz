using System.Text.Json;
using FizzBuzzProject.Exceptions;
using FizzBuzzProject.Interfaces;
using FizzBuzzProject.Models;
using FizzBuzzProject.Rules;

namespace FizzBuzzProject.Core;

/// <summary>
/// Builds rules by fetching them from an external API.
/// </summary>
public class ApiRuleBuilder(string apiUrl) : IRuleBuilder
{
    private static readonly HttpClient HttpClient = new HttpClient();

    public async Task<List<IRule>> BuildRulesAsync()
    {
        try
        {
            var response = await HttpClient.GetStringAsync(apiUrl);
            var apiRules = JsonSerializer.Deserialize<List<ApiRuleModel>>(response);

            if (apiRules == null || !apiRules.Any())
                throw new RuleBuildingException(
                    "No rules received from the API. \nPlease ensure that the correct URL is utilized in appsettings.json and check the API response manually for expected results. \nAPI-owner may have changed the endpoint.");

            var rules = new List<IRule>();

            foreach (var apiRule in apiRules)
            {
                try
                {
                    var rule = new DivisibleRule(apiRule.Number, apiRule.Word);
                    rules.Add(rule);
                }
                catch (RuleValidationException ex)
                {
                    throw new RuleBuildingException(
                        $"Invalid rule from API (Number: {apiRule.Number}, Word: '{apiRule.Word}'): {ex.Message}", ex);
                }
            }

            return rules;
        }
        catch (HttpRequestException ex)
        {
            throw new ApiException(
                "Failed to fetch rules from the API. Please ensure the URL is correctly configured in appsettings.json and that you have a stable internet connection.",
                ex);
        }
        catch (JsonException ex)
        {
            throw new RuleBuildingException("Failed to deserialize rules from the API.", ex);
        }
    }
}