- Teste para Pleno WebMotors.
- Utilizei um template para realizar o teste de vocês.
- É um template com diversas camadas utilizando DDD, CQRS, diversos patterns para se aproximar daquilo que é o mundo real.


# Techs
- ASP.NET Core 5.0 (with .NET Core 5.0)
- ASP.NET WebApi Core
- ASP.NET Identity Core
- Entity Framework Core
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI
- MSSQL
- Fluent Assertions
- Polly
- Refit

# Design Patterns
- Domain Driven Design
- Domain Events
- Domain Notification
- CQRS
- Event Sourcing
- Unit Of Work
- Repository & Generic Repository
- Inversion of Control / Dependency injection
- ORM
- Mediator
- Specification Pattern
- Options Pattern

# Iniciar projeto
- Setar WebMotorApi como iniciador do projeto. Usar ambiente Dev e verificar appsettings.
- Deve-se rodar as migrations em seus respectiovs contextos. Exemplo:
- update-database -context AuthDbContext, ApplicationDbContext e EventStoreSqlContext / Vai dar pau se não gerar essas migrations bonitinhas.
- Depois de geradas, iniciar o projeto no VS, registrar um user, e chamar as apis.

# Swagger (Dev)
- http://localhost:5000/swagger
