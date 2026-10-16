# Moumen Khaled — Products API

ASP.NET Core 8 Web API using Clean Architecture, CQRS/MediatR, Entity Framework Core and FluentValidation.

## Features
- List products: `GET /api/products`
- Search products by name: `GET /api/products?search=phone`
- Sort products by price ascending: `GET /api/products?sortByPrice=true`
- Find a product: `GET /api/products/{id}`
- Create a product: `POST /api/products`

## Run
Open `MoumenProductsSolution.sln` in Visual Studio, restore NuGet packages, configure the database connection in `MoumenProducts.API/appsettings.json`, then run the API project.

Prepared for: **Moumen Khaled**.

Note: build output (`bin`, `obj`) and Visual Studio local cache (`.vs`) were excluded; they are regenerated when building.
