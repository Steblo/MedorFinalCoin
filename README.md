MedorFinal

Kompletní řešení pro práci s daty z ČNB, ukládání klientů a správu dat přes API i Blazor WebAssembly frontend.

------------------------------------------------------------
Struktura řešení
------------------------------------------------------------

CNB/
  Modul pro komunikaci s API České národní banky a získávání kurzů.

FE/
  Blazor WebAssembly frontend.
  Obsahuje UI, služby pro komunikaci s API a klientskou logiku.

Medor/
  Backend (ASP.NET Core Web API).
  Obsahuje controllery, služby a konfiguraci aplikace.

Shared.Data/
  Datová vrstva s entitami a AppDbContext.
  Obsahuje EF Core migrace.

------------------------------------------------------------
Technologie
------------------------------------------------------------

- .NET 10
- ASP.NET Core Web API
- Blazor WebAssembly
- Entity Framework Core
- SQL Server
- Dependency Injection
- JSON model binding

------------------------------------------------------------
Databáze a migrace
------------------------------------------------------------

Migrace jsou umístěny v projektu Shared.Data.

Vytvoření nové migrace:
Add-Migration NazevMigrace -Project Shared.Data

Aplikace migrace:
Update-Database -Project Shared.Data

------------------------------------------------------------
Spuštění projektu
------------------------------------------------------------

Backend (Medor):
1. Otevři řešení ve Visual Studiu
2. Nastav projekt Medor jako startup
3. Spusť (F5)

Frontend (FE):
1. Otevři složku FE
2. Spusť:
dotnet run

Aplikace poběží na:
https://localhost:7002

------------------------------------------------------------
Komunikace FE ↔ API
------------------------------------------------------------

Frontend komunikuje s backendem přes HTTP klienta.
URL API je nastavena v appsettings.json nebo ve službách FE.

------------------------------------------------------------
Build & Publish
------------------------------------------------------------

Backend:
dotnet publish -c Release

Frontend:
dotnet publish -c Release

------------------------------------------------------------
Licence
------------------------------------------------------------

Projekt je veřejný a může být dále rozšiřován.
