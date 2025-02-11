using FizzBuzzProject.Core;
using FizzBuzzProject.Exceptions;
using FizzBuzzProject.Interfaces;
using Microsoft.Extensions.Configuration;

try
{
    // Load configuration from appsettings.json
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

    // Read configuration settings
    var defaultStart = configuration.GetValue("FizzBuzzSettings:DefaultStart", 1);
    var defaultEnd = configuration.GetValue("FizzBuzzSettings:DefaultEnd", 100);
    var reversed = configuration.GetValue("FizzBuzzSettings:Reversed", false);

    // Read API settings or throw an exception if they are missing
    var ruleApiType = configuration.GetValue<string>("FizzBuzzSettings:RuleApi");
    if (string.IsNullOrWhiteSpace(ruleApiType))
    {
        throw new ConfigurationException(
            "The 'RuleApi' setting is missing or empty in the appsettings.json configuration file.");
    }

    var baseUrl = configuration.GetValue<string>("ApiUrls:BaseUrl");
    if (string.IsNullOrWhiteSpace(baseUrl))
    {
        throw new ConfigurationException(
            "The 'BaseUrl' setting is missing or empty in the appsettings.json configuration file.");
    }

    var staticEndpoint = configuration.GetValue<string>("ApiUrls:StaticRulesEndpoint");
    if (string.IsNullOrWhiteSpace(staticEndpoint))
    {
        throw new ConfigurationException(
            "The 'StaticRulesEndpoint' setting is missing or empty in the appsettings.json configuration file.");
    }

    var dynamicEndpoint = configuration.GetValue<string>("ApiUrls:DynamicRulesEndpoint");
    if (string.IsNullOrWhiteSpace(dynamicEndpoint))
    {
        throw new ConfigurationException(
            "The 'DynamicRulesEndpoint' setting is missing or empty in the appsettings.json configuration file.");
    }

    // Construct full API URLs
    var staticApiUrl = $"{baseUrl}/{staticEndpoint}";
    var dynamicApiUrl = $"{baseUrl}/{dynamicEndpoint}";

    // Choose which API URL to use
    var apiUrl = ruleApiType == "dynamic" ? dynamicApiUrl : staticApiUrl;

    // Use ApiRuleBuilder with the constructed API URL
    IRuleBuilder ruleBuilder = new ApiRuleBuilder(apiUrl);

    // Build the rules
    var rules = await ruleBuilder.BuildRulesAsync();

    // Create RuleEngine and run the game with the rules
    var engine = new RuleEngine(rules);

    var gameDescription = $"Running game with {ruleApiType} API-rules";

    var gameRunner = new GameRunner(engine);
    gameRunner.Run(defaultStart, defaultEnd, reversed, gameDescription);
}
catch (ConfigurationException ex)
{
    Console.WriteLine($"Configuration error:\n{ex.Message}");
    Environment.Exit(1);
}
catch (RuleBuildingException ex)
{
    Console.WriteLine($"Error during rule building:\n{ex.Message}");
    Environment.Exit(1);
}
catch (ApiException ex)
{
    Console.WriteLine($"Error during API request:\n{ex.Message}");
    Environment.Exit(1);
}