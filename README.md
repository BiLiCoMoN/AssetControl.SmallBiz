# AssetControl.SmallBiz

Small, modular ASP.NET Core (net9.0) sample derived from AssetControl Enterprise. Purpose: fast MVP for small businesses with modular structure for Customers / Products / Orders.

Quick start

1. Build

```powershell
cd "src\AssetControl.SmallBiz"
dotnet build
```

2. Run

```powershell
dotnet run
```

3. Open browser: `http://localhost:5000` - pages: `/Customers`, `/Products`, `/Orders`.

Notes
- Database: SQLite (default `smallbiz.db`). Migrations are included under `Migrations/`.
- Architecture: modules under `Modules/<ModuleName>` with `Models`, `Dtos`, `Pages`, `Services`.

Roadmap
- Add validation (DataAnnotations / FluentValidation)
- Introduce DTOs and AutoMapper mapping
- Add integration tests with TestServer
- Add Dockerfile and CI container job
- Add JWT authentication and protect write endpoints
# AssetControl.SmallBiz

Micro project focused on small manufacturing/service businesses. Minimal API + EF Core (SQLite).

Run locally:

```powershell
cd "src/AssetControl.SmallBiz"
dotnet restore
dotnet run --urls "http://localhost:5180"
```

Endpoints:
- GET / (info)
- GET /health
- GET /api/customers
- POST /api/customers

Push to a new GitHub repo (your user: BiLiCoMoN)

Using GitHub CLI (recommended):

```powershell
cd "src/AssetControl.SmallBiz"
gh repo create BiLiCoMoN/AssetControl.SmallBiz --public --source=. --remote=origin --push
```

Manual git push:

```powershell
cd "src/AssetControl.SmallBiz"
git init
git add .
git commit -m "Initial SmallBiz minimal API"
# create empty repo on GitHub named AssetControl.SmallBiz
git remote add origin https://github.com/BiLiCoMoN/AssetControl.SmallBiz.git
git branch -M main
git push -u origin main
```

Next steps:
- Add CI (template included in `repo-templates/smallbiz-template`)
- Add migrations and seed data
- Add authentication and a small UI (Blazor or SPA)

