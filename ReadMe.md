# Project Structure and Progress
```
ecommerce-platform/
│
├── frontend/ 
│   ├── src/
│   ├── public/
│   └── package.json
│
├── backend/
│   │
│   ├── eShop.Core/
│   │   │
│   │   ├── Common/
│   │   │   ├── Models/
│   │   │   ├── Exceptions/
│   │   │   └── Utilities/
│   │   │
│   │   ├── Products/
│   │   │   ├── Entities/ [DONE]
│   │   │   ├── DTOs/ [DONE]
│   │   │   ├── Interfaces/ [DONE]
│   │   │   ├── Services/ [DONE]
│   │   │   ├── Validators/
│   │   │   └── Exceptions/
│   │   │
│   │   ├── Cart/
│   │   │   ├── Entities/
│   │   │   ├── StateMachines/
│   │   │   ├── DTOs/
│   │   │   ├── Services/
│   │   │   └── Interfaces/
│   │   │
│   │   ├── Orders/
│   │   │
│   │   ├── Auth/
│   │   │
│   │   └── Analytics/
│   │
│   ├── eShop.Data/
│   │   │
│   │   ├── Context/
│   │   ├── Configurations/
│   │   ├── Repositories/
│   │   ├── Migrations/
│   │   ├── Seed/
│   │   └── Mock/
│   │
│   ├── eShop.API/
│   │   │
│   │   ├── Controllers/
│   │   ├── Middleware/
│   │   ├── Extensions/
│   │   ├── Filters/
│   │   ├── Swagger/
│   │   ├── appsettings.json
│   │   └── Program.cs
│   │
│   └── eShop.sln
│
├── tests/
│   ├── eShop.Core.Tests/
│   ├── eShop.API.Tests/
│   └── eShop.IntegrationTests/
│
├── infrastructure/
│   ├── podman/
│   ├── nginx/
│   ├── compose.yml
│   └── monitoring/
│
└── README.md
```