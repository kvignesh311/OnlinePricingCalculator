# Pricing Calculator API

This project is hosted in https://onlinepricingcalculator.onrender.com/

## About this project

This is a .NET 8 Minimal API project built to calculate item pricing
with different types of discounts.

It supports:

-   Percentage discounts (5%, 10%, 20%, etc.)
-   Buy X Get Y Free (Buy 1 Get 1, Buy 2 Get 1, etc.)

If multiple discounts apply to the same item, the system calculates all
of them and applies only the one that gives the maximum benefit to the
customer. Discounts are not stacked.

The solution follows Clean Architecture principles to keep business
logic separate from infrastructure and API layers.

## Project Structure

-   **PricingCalculator.Domain** -- Entities and core business logic\
-   **PricingCalculator.Application** -- Use cases, DTOs, interfaces\
-   **PricingCalculator.Infrastructure** -- EF Core, database,
    repository\
-   **PricingCalculator.Api** -- Minimal API endpoints and DI setup

## Technology Used

-   .NET 8
-   Minimal API
-   Entity Framework Core
-   PostgreSQL (Supabase)
-   Clean Architecture pattern

## API Endpoints

### GET https://onlinepricingcalculator.onrender.com/api/items

Returns all active items.

### POST https://onlinepricingcalculator.onrender.com/api/pricing/calculate

Example request:

{ "items": \[ { "itemId": 1, "quantity": 3 }, { "itemId": 2, "quantity":
2 } \] }

Returns detailed pricing with discount amount and total payable.

## Running the Project locally

1.  Update postgre sql connection string in appsettings.json

2.  Run migrations:

    dotnet ef database update -p PricingCalculator.Infrastructure -s
    PricingCalculator.Api

3.  Run API:

    dotnet run --project PricingCalculator.Api

4.  Open Swagger in browser: https://localhost:{port}/swagger
