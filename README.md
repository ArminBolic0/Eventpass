# 🎟️ EventPass - Clean Architecture Event Ticketing App

EventPass is a full-stack web application for managing and purchasing event tickets.
Built with **.NET 8, EF Core, CQRS, MediatR, FluentValidation, JWT Authentication**, and **Angular** frontend.

## Backend Architecture
- **Domain** – Entities & Interfaces
- **Application** – CQRS commands, queries, validators
- **Infrastructure** – Repositories, EF Core, Security
- **API** – Controllers, Middleware, DI setup

## Features
- JWT authentication & authorization
- Event, Venue, Performer, Sponsor management
- Cart, Order & Ticket workflows
- Clean Architecture with CQRS pattern
- SQL Server with EF Core Migrations

## Tech Stack
- ASP.NET Core 8
- Entity Framework Core
- MediatR + FluentValidation
- SQL Server
- Angular 20
- Swagger / OpenAPI

## 🚀 Getting Started
1. Clone the repository
2. Update `appsettings.json` connection string
3. Run migrations:
   ```bash
   dotnet ef database update
