# ADS SQL API Core 10

## Architecture Summary

| Area | Decision |
| --- | --- |
| Architecture Style | 3-Tier + CQRS |
| Database Style | Code First |
| Data Access | EF Core + Repository Pattern |
| CQRS | Command + Queries (Read & Write) |
| DTOs | Request/Response DTOs at API boundary |
| Caching | Not required |
| Resiliency | Retry for transaction and scope during data writes |
| Authentication | Managed Identity |

## Solution Structure

```text
.
├── ADS.SqlApi.sln
├── Directory.Build.props
├── src
│   ├── AdsSqlApi.Api
│   ├── AdsSqlApi.Application
│   ├── AdsSqlApi.Domain
│   └── AdsSqlApi.Infrastructure
└── tests
    └── AdsSqlApi.Tests
```

### Project Responsibilities

- `AdsSqlApi.Api`: HTTP surface, controllers, Swagger, and composition root.
- `AdsSqlApi.Application`: CQRS contracts, DTOs, use-case boundaries, and persistence abstractions.
- `AdsSqlApi.Domain`: core domain entities and shared domain primitives.
- `AdsSqlApi.Infrastructure`: EF Core, SQL Server access, repositories, and managed identity integration.
- `AdsSqlApi.Tests`: unit and integration tests for the application and infrastructure layers.

## 3-Tier Mapping

- Presentation tier: `AdsSqlApi.Api`
- Business tier: `AdsSqlApi.Application` + `AdsSqlApi.Domain`
- Data tier: `AdsSqlApi.Infrastructure`

## Code First Notes

- The domain entities define the schema.
- `AppDbContext` and entity configurations control table names, keys, indexes, and relationships.
- `AppDbContextFactory` is ready for `dotnet ef migrations add InitialCreate`.

## SQL Server Connection

- Default local development connection string uses `LocalDB`:
  - `Server=(localdb)\\MSSQLLocalDB;Database=AdsSqlApiCodeFirst;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True`
- For Azure SQL, replace `ConnectionStrings:SqlDatabase` with your server name and Managed Identity authentication string.
- The infrastructure layer already uses `UseSqlServer(...)` with retry enabled.

## DTO Flow

- Controllers accept request DTOs from `AdsSqlApi.Application.DTOs`.
- Controllers dispatch CQRS commands and queries.
- Handlers return response DTOs instead of EF entities.
- Domain entities stay inside the business/data boundary.

## Available APIs

- `POST /api/organizations`
- `GET /api/organizations/{id}`
- `PUT /api/organizations/{id}`
- `DELETE /api/organizations/{id}`
- `POST /api/employees`
- `GET /api/employees/{id}`
- `PUT /api/employees/{id}`
- `DELETE /api/employees/{id}`

## Notes

- Use EF Core for database access and keep repository abstractions focused on persistence concerns.
- Separate write operations and read operations using CQRS to keep the API structure clear and maintainable.
- Do not introduce caching unless a concrete performance need appears later.
- Apply retry handling around write operations, especially where transaction or scope boundaries can fail transiently.
- Prefer Managed Identity for authentication to avoid storing secrets in configuration.
