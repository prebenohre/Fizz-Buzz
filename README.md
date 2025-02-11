# FizzBuzz Project

## Introduction
This project is a unique take on the classic FizzBuzz game, where the rules are dynamically fetched from an [external API running in Azure](https://fizz-buzz-api-frbddabua6ave7ct.norwayeast-01.azurewebsites.net/api/FizzBuzz/dynamic). The goal of this project was to challenge myself to write clean, scalable, and maintainable code in C#, following SOLID principles and best practices for object-oriented programming.

Instead of hardcoded rules for numbers divisible by 3 and 5, this implementation allows the application to retrieve rules from an external API, which can return either static or dynamic rules. This enables rule changes without modifying the source code and makes it easy to extend the solution with new rules, alternative data sources, and different game modes.

Watch a video demo of the project here: [https://fizz-buzz-api-frbddabua6ave7ct.norwayeast-01.azurewebsites.net/api/FizzBuzz/dynamic](https://drive.google.com/file/d/1MmgNuyZC3z0FM4EokCa5UIrX_hwc8RzG/view?usp=sharing)
  
---  

## Functionality
The program performs the following operations:

1. **Dynamic Rule Fetching**:
    - Fetches rules from external APIs at runtime:
        - **Static Rules API**: Always returns rules for numbers divisible by 3 (`"Preben"`) and 5 (`"Øhre"`).
        - **Dynamic Rules API**: Returns a randomized set of two rules on each request (e.g., 4-Random, 7-Word).
    - The chosen API source is determined by the `RuleApi` setting in `appsettings.json`.

2. **Game Execution**:
    - Runs the game for a configurable range of numbers, applying the fetched rules dynamically.
    - Showing which rules are applied to each number, and outputs the results.

3. **Rule Configuration**:
    - By adjusting `appsettings.json`, you can switch between using the static or dynamic API without changing the code.
    - Supports running the sequence in normal or reversed order based on configuration.

---

## Technical Design
This part builds upon the structure established in previous parts, adding support for API integration.

### **1. `Program`**
- **Responsibility**: The entry point for the application.
- **Key Responsibilities**:
    - Loads configuration from `appsettings.json`.
    - Determines whether to use the static or dynamic API endpoint based on `RuleApi`.
    - Instantiates `ApiRuleBuilder` to fetch rules from the selected endpoint.
    - Initializes the `RuleEngine` and `GameRunner` to execute and display the game results.

### **2. `ApiRuleBuilder`**
- **Responsibility**: Fetches and constructs rules from an external API.
- **Key Responsibilities**:
    - Performs an HTTP GET request to the configured URL.
    - Deserializes the returned JSON into `ApiRuleModel` instances.
    - Converts these models into `DivisibleRule` objects.
    - Throws `RuleBuildingException` if no rules are returned or if a rule is invalid, and `ApiException` if the request 
      fails.

### **3. `Interfaces`**
- **`IRule`**:
    - Defines methods for checking if a number matches the rule (`IsMatch`) and retrieving its replacement text (`GetReplacement`).
- **`IRuleBuilder`**:
    - Defines `BuildRulesAsync()` for constructing a list of `IRule` objects from any source (in this case, the external API).

### **4. `RuleEngine`**
- **Responsibility**: Evaluates which rules apply to each number in the given range.
- **Key Responsibilities**:
    - Applies all rules to a given number.
    - Returns the concatenated replacement string if one or more rules match, or the number as a string if none match.

### **5. `GameRunner`**
- **Responsibility**: Iterates through a specified numeric range, applying the rules via `RuleEngine`.
- **Key Responsibilities**:
    - Prints the list of applied rules before running the numbers.
    - Supports reversed iteration if configured.
    - Displays the result for each number and any combined rules that apply.

### **6. `ApiRuleModel`**
- **Responsibility**: Represents the structure of rules fetched from the API.
- **Attributes**:
    - `Number`: Divisor used to determine if a rule matches a given number.
    - `Word`: Replacement text to print when the rule matches.

### **7. `Exceptions`**
- **`BaseException`**: Base class for custom exceptions, providing a common hierarchy.
- **`ApiException`**: Thrown when API requests fail due to network issues or unreachable endpoints.
- **`ConfigurationException`**: Thrown when required configuration settings are missing or invalid.
- **`RuleBuildingException`**: Thrown if no rules are returned or if the rules fetched cannot be used.
- **`RuleValidationException`**: Thrown when a rule is constructed with invalid parameters (e.g., divisor = 0).

### **8. `Rules`**
- **`BaseRule`**: 
    - Abstract base class implementing `IRule`.
    - Outlines the contract for all concrete rules.
- **`DivisibleRule`**:
    - Checks whether a number is divisible by the specified divisor.
    - Returns the associated replacement string if the rule matches.
    - Validates inputs and throws `RuleValidationException` for invalid configurations.

---

## Testing
The following test cases cover various aspects of the rule-building and rule-application logic:

### **Test Coverage**
- **`RuleEngineTests`**:
    - Checks behavior when no rules match (returns the number).
    - Ensures that a single matching rule returns the correct replacement.
    - Verifies that multiple matches produce a concatenated result.
- **`DivisibleRuleTests`**:
    - Ensures that numbers divisible by the rule’s divisor match correctly.
    - Checks that invalid divisors or empty replacements trigger `RuleValidationException`.
    - Confirms that `GetReplacement()` returns the correct string.

---

## Example Outputs
Sample outputs for games using static and dynamic rules:

1. **Static Rules API**:
    ```
    Running game with static API rules
    Applied Rules:
    - If divisible by 3, print 'Preben'
    - If divisible by 5, print 'Øhre'
    - If divisible by 3 and 5, print 'PrebenØhre'

    1
    2
    Preben
    4
    Øhre
    Preben
    7
    8
    Preben
    Øhre
    11
    Preben
    13
    14
    PrebenØhre
    ...
    ```

2. **Dynamic Rules API**:
    ```
    Running game with dynamic API rules
    Applied Rules:
    - If divisible by 4, print 'Random'
    - If divisible by 7, print 'Word'
    - If divisible by 4 and 7, print 'RandomWord'

    1
    2
    3
    Random
    5
    6
    Word
    Random
    9
    10
    11
    RandomWord
    13
    14
    15
    ...
    ```

---

## Extensibility
The architecture adheres to the **Open/Closed Principle** (OCP), allowing for:
- Seamless addition of new rule sources (e.g., databases or other APIs).
- Reuse of the `RuleEngine` and `GameRunner` components for alternative games.
- Enhanced error handling and future extension for new types of rules or endpoints.

---
## Configuration
The application’s behavior is controlled via `appsettings.json`:

```json
{
  "FizzBuzzSettings": {
    "DefaultStart": 1,
    "DefaultEnd": 100,
    "Reversed": false,
    "RuleApi": "dynamic"
  },
  "ApiUrls": {
    "BaseUrl": "https://fizz-buzz-api-frbddabua6ave7ct.norwayeast-01.azurewebsites.net/api/FizzBuzz/",
    "StaticRulesEndpoint": "static",
    "DynamicRulesEndpoint": "dynamic"
  }
}
```
### Key Settings:
- `RuleApi`: Determines if the application uses `static` or `dynamic` rules.
- `DefaultStart` and `DefaultEnd`: Configure the game’s numeric range.
- `Reversed`: Decides whether to iterate backwards.
- `ApiUrls`: Specifies the base URL and endpoints for fetching the rules.

