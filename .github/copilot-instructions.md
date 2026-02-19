<!-- Use this file to provide workspace-specific custom instructions to Copilot. -->

# StudentService — Copilot Instructions

## Project Overview
A simple ASP.NET Core Web API microservice with CRUD endpoints for a `Student` entity, backed by an EF Core In-Memory database.

## Stack
- **Runtime**: .NET 10
- **Framework**: ASP.NET Core Web API (controller-based)
- **ORM**: Entity Framework Core with In-Memory provider

## Key Files
- `Program.cs` — DI setup and middleware pipeline
- `Models/Student.cs` — Student entity
- `Data/AppDbContext.cs` — EF Core DbContext
- `Controllers/StudentsController.cs` — CRUD REST controller

## Guidelines
- Follow RESTful conventions for new endpoints.
- Keep business logic out of controllers; move to service classes if the project grows.
- The in-memory database resets on every restart — for persistence, swap `UseInMemoryDatabase` with a real provider.
