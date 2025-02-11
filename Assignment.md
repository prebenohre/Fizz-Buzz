# FizzBuzz, JazzFuzz Assignment

This repository contains a solution to the **FizzBuzz, JazzFuzz** assignment, designed to test programming skills and adherence to best practices. The task is split into three parts, with a focus on clean, maintainable, and scalable code. Below is the detailed task description and requirements.

---

## Assignment Overview

### General Instructions:
1. **Programming Language:** C# (Console application).
2. **Repository Management:**
    - Share your solution on GitHub with the following profiles:
        - [Andrea Huse](https://github.com/AndreaHuse)
        - [Kristian Borg (CTO)](https://github.com/BorgKristian)
        - [Thomas Leela (Backend Lead)](https://github.com/tholee)
        - [Balder Ulfeng (Senior Backend Developer)](https://github.com/Redlab1)
    - Use separate branches for each part of the assignment to clearly distinguish solutions.
    - Enable GitHub Discussions for review and feedback.

3. **Important Considerations:**
    - Follow **clean code** principles. Avoid over-engineering or unnecessary complexity.
    - Focus on **technical quality**, including naming conventions, file/project organization, and scalability.
    - Use **SOLID principles** and modern C# features where applicable.
    - If possible, include unit tests (XUnit is preferred), but prioritize a solid solution over incomplete testing.

---

## Tasks

### **Part 1: FizzBuzz Basics**
- Implement the classic **FizzBuzz** game.
- Requirements:
    - Print numbers 1 through 100.
    - Replace numbers divisible by 3 with "Fizz".
    - Replace numbers divisible by 5 with "Buzz".
    - Replace numbers divisible by both 3 and 5 with "FizzBuzz".
- Focus on simplicity and adhere to known programming principles.

---

### **Part 2: JazzFuzz Expansion**
- Extend the FizzBuzz game with additional functionality:
    1. Run FizzBuzz as usual (1-100).
    2. Run the game in reverse (100-1) with new rules:
        - Replace numbers divisible by 9 with "Jazz".
        - Replace numbers divisible by 4 with "Fuzz".
    3. Prepare the solution for potential future changes.
- Deliverables:
    - Clean and maintainable code following **Open/Closed Principle (OCP)**.
    - Generic class, method, and file naming to accommodate future extensions.

---

### **Part 3: Dynamic Rule Integration**
- Fetch game rules from external APIs before executing the game.
    - **Static API:** For development and testing, returns rules: 3-Fizz, 5-Buzz.
        - URL: `https://epinova-fizzbuzz.azurewebsites.net/api/static-rules`
    - **Dynamic API:** For demonstration, provides unique rules each time (e.g., 4-Gizz, 7-Hizz).
        - URL: `https://epinova-fizzbuzz.azurewebsites.net/api/dynamic-rules`
- Requirements:
    - Display the fetched rules before executing the game.
    - Implement the change in a separate branch and submit as a pull request.

---

## Tips and Best Practices

- Use a `.gitignore` file to keep the repository clean.
- Write code that takes advantage of modern C# features, avoiding outdated patterns.
- Strive for **self-documenting code**, using XML documentation comments (`///`) where necessary.
- Use generic and future-proof naming conventions for classes, files, and methods.
- Design the solution to be **open for extension but closed for modification (OCP)**.
- Evaluate robustness by imagining potential future extensions, such as adding rules like:
    - `Kizz` (2), `Bozz` (6), `Lezz` (7).

---

## How to Submit
1. Push your solution to a GitHub repository.
2. Share the repository with the profiles listed above.
3. Ensure GitHub Discussions are enabled for feedback.
