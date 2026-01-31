# Answers to Technical Questions

## 1. How long did you spend on the coding assignment? What would you add if you had more time?

I spent approximately **6–8 hours** on this assignment, including development, debugging API integrations, and improving code structure.

If I had more time, I would:
- Add caching (e.g., MemoryCache) to reduce external API calls
- Improve UI/UX with better validation and loading indicators
- Add integration tests in addition to unit tests
- Add logging and error-handling middleware
- Dockerize the application for easier deployment

---

## 2. What was the most useful feature added to the latest version of your language of choice?

One of the most useful recent features in **C#** is **record types**, which simplify immutable data modeling.

### Example:
```csharp
public record CryptoPriceResult(
    string Symbol,
    decimal PriceUsd,
    Dictionary<string, decimal> ConvertedPrices
);
3. How would you track down a performance issue in production? Have you ever done this?

To track a performance issue in production, I would:

Analyze application logs and metrics

Use APM tools (e.g., Application Insights)

Monitor CPU, memory, and response times

Reproduce the issue in a staging environment

Profile slow endpoints and database queries

Yes, I have previously diagnosed performance issues related to inefficient API calls and unoptimized database queries.

4. What was the latest technical book or conference you attended? What did you learn?

Recently, I studied materials related to Clean Architecture and .NET performance optimization.

I learned:

Importance of separation of concerns

Dependency inversion for testability

Writing scalable and maintainable backend services

5. What do you think about this technical assessment?

I believe this assessment is well-designed and practical.
It evaluates:

Real-world API integration

Code quality and structure

Clean architecture and testing practices

It reflects real backend development scenarios.

#############################################



{
  "name": "Mostafa Tofighi",
  "title": "Software Engineer",
  "primaryStack": ".NET / C#",
  "experience": "Backend and Web Development",
  "skills": [
    "ASP.NET Core",
    "RESTful APIs",
    "Entity Framework",
    "Unit Testing",
    "Clean Architecture",
    "Git & GitHub"
  ],
  "interests": [
    "Backend Development",
    "System Design",
    "Performance Optimization",
    "FinTech"
  ],
  "strengths": [
    "Problem Solving",
    "Clean Code",
    "Learning New Technologies"
  ],
  "mindset": "I enjoy building reliable and maintainable software solutions."
}