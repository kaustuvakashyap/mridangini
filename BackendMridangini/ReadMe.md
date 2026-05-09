# Project Structure"

```ecommerce-platform/
│
├── frontend/
│
├── backend/
│   ├── eShop.Core/
│   │   ├── Entities/
│   │   ├── DTOs/
│   │   ├── Interfaces/
│   │   ├── Services/
│   │   ├── StateMachines/
│   │   └── Enums/
│   │
│   ├── eShop.Data/
│   │   ├── Context/
│   │   ├── Repositories/
│   │   ├── Configurations/
│   │   ├── Migrations/
│   │   └── Mock/
│   │
│   ├── eShop.API/
│   │   ├── Controllers/
│   │   ├── Middleware/
│   │   ├── Extensions/
│   │   └── Program.cs
│   │
│   └── eShop.sln
│
├── tests/
│
├── infrastructure/
│   ├── compose.yml
│   └── nginx/
│
└── README.md```