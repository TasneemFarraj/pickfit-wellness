# PickFit Wellness — Backend API

PickFit is a nutrition and wellness platform built as a graduation project. This repository contains its **REST API**, which powers healthy meal browsing (recipes, ingredients, preparation steps, nutrition facts), a directory of nutrition specialists, and appointment booking.

## Features

- **Healthy meals:** meal cards with images, recipes (prep time, cooking time, servings, difficulty), ingredients, step-by-step preparation, and nutrition facts (calories, protein, carbs, fats).
- **Specialists directory:** information cards for nutrition specialists, filterable by specialty (therapeutic nutrition, children & elderly nutrition, sports nutrition, preventive nutrition), with an activation step from the dashboard.
- **Appointments:** users can book an appointment with a specialist.
- **Accounts:** user registration and login with JWT tokens, two account types (User / Specialist), and user profiles with photos.
- **Site content:** home page sections, certificates, and frequently asked questions.
- **Image uploads:** images are stored on the server and served as static files.

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core Web API (.NET 8) |
| Database | SQL Server with Entity Framework Core 8 (code-first migrations) |
| Auth | JWT Bearer tokens |
| Mapping | AutoMapper |
| Docs | Swagger / OpenAPI |

## Architecture

The project follows a layered structure using the **Repository** and **Unit of Work** patterns:

```
FITTNESS/
├── Controllers/      # API endpoints, one controller per resource
├── Repository/
│   ├── IRepo/        # Repository interfaces
│   └── Repo/         # EF Core implementations
├── UnitOfWork/       # Groups all repositories behind one injectable service
├── Data/
│   ├── Models/       # Entities + AppDBContext
│   └── Enum/         # User types, specialist types, file types
├── Dtos/             # Read / Write DTOs (validation lives here)
├── AutoMapper/       # Entity <-> DTO mappings
├── Authorization/    # JWT token generation
├── Upload/           # Image upload helper
├── Response/         # Standard JSON response envelope
└── Migrations/       # EF Core migrations
```

Every endpoint returns the same response shape:

```json
{
  "success": true,
  "code": 200,
  "message": "Show Rows",
  "result": { }
}
```

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (Express or LocalDB is fine)

### 1. Clone

```bash
git clone https://github.com/TasneemFarraj/pickfit-wellness.git
cd pickfit-wellness/FITTNESS
```

### 2. Configure secrets

Secrets are **not** stored in the repository. Set them locally with .NET User Secrets:

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:mycon" "Server=localhost;Database=FITTNESS;Trusted_Connection=True;TrustServerCertificate=True"
dotnet user-secrets set "Jwt:Key" "<a random string of at least 32 characters>"
```

### 3. Create the database

```bash
dotnet tool install --global dotnet-ef   # if you don't have it
dotnet ef database update
```

### 4. Run

```bash
dotnet run
```

Then open Swagger at **https://localhost:5001/swagger**.

## API Overview

| Resource | Base route | Main endpoints |
|---|---|---|
| Users | `/api/User` | `AddUser`, `Login` |
| Profiles | `/api/ProfileUser` | CRUD with photo upload |
| Specialists | `/api/InformationCard` | CRUD, `GetCardInformationByType/{type}`, dashboard list, activate/deactivate |
| Appointments | `/api/Appointment` | CRUD |
| Meal cards | `/api/Palate1` | CRUD with image upload |
| Meal images | `/api/PalateImg` | CRUD with image upload |
| Recipes | `/api/PalateRecipe` | CRUD |
| Ingredients | `/api/PalateIngredient` | CRUD |
| Preparation | `/api/PalatePrepare` | CRUD |
| Nutrition | `/api/PalateNutrition` | CRUD |
| Home | `/api/Home` | CRUD |
| Certificates | `/api/Certificate` | CRUD with image upload |
| FAQ | `/api/FrequentlyQuestion` | CRUD |

Full request/response details are available in Swagger.

## Roadmap

Planned improvements:

- [ ] Hash passwords (PBKDF2 / BCrypt) instead of storing them as plain text
- [ ] Protect write endpoints with `[Authorize]` and role-based access
- [ ] Global exception handling middleware and proper HTTP status codes
- [ ] Store phone numbers as strings
- [ ] Unit tests and a Dockerfile
