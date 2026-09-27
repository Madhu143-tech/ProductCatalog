# Forma Goods — Product Catalog

A small ASP.NET Core MVC catalog app built with controllers, data-annotated models, Razor views, and conventional plus attribute-style routes.

## Run locally

Requires the .NET 10 SDK.

### Visual Studio

Open `ProductCatalog.sln` from the parent `outputs` folder. Select the **http** launch profile and press **F5**. Visual Studio will build the project and open the catalog at `http://localhost:5121`.

```powershell
dotnet run
```

Open the local URL printed by `dotnet run`. The catalog is the default page; product details also resolve at `/products/{id}`.

## Features

- Browse a seeded collection of eight products.
- Search by name or description, filter by category, and sort by featured, price, or name.
- View product details and create, edit, or delete products.
- Server and browser-side validation for product fields.
- Responsive layout with custom styling.

## Project structure

- `Controllers/ProductsController.cs` — catalog, detail, and CRUD actions.
- `Models/Product.cs` and `Models/CatalogViewModel.cs` — domain and view models.
- `Services/ProductCatalogService.cs` — seeded in-memory catalog operations.
- `Views/Products/` — Razor catalog, details, and management screens.
- `Program.cs` — dependency registration and MVC routing.

The sample catalog is held in memory and resets when the app restarts. Replace `ProductCatalogService` with an EF Core repository and a database when durable storage is needed.
