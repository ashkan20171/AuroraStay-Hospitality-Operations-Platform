# AuroraStay Hospitality Operations Suite

**A portfolio-grade bilingual hotel operations and property management desktop suite built with C# and .NET Framework 4.8.**

AuroraStay demonstrates how a traditional WinForms application can be evolved into a polished, operator-focused hospitality product with a premium visual system, secure local authentication, bilingual RTL/LTR UX and operational intelligence.

## Highlights

- Premium European-inspired dark hospitality UI with glass surfaces and hotel artwork
- Persian-first RTL and English LTR localization
- Reservation management with conflict validation
- Live room status board and room availability workflow
- Guest directory, Guest Profile & Folio, and **Guest Intelligence 360°**
- Housekeeping board, priorities, assignments and completion workflow
- Billing, folio charges and payments
- Reservation calendar and operational notifications
- **Operations Command Center** with health score and attention queue
- Global guest / room / reservation search
- Staff, service catalog, audit log, backup and restore tools
- PBKDF2-SHA256 salted password hashing and fixed-time hash comparison
- Local XML persistence with backup and corrupt-file preservation
- Bilingual navigation and status-aware data grids

## Why this project

The goal is not to mimic a web dashboard inside WinForms. AuroraStay focuses on desktop operator productivity: quick visual scanning, low-friction front-desk actions, strong status hierarchy, readable dense data and resilient local operation.

## Architecture

The solution keeps responsibilities deliberately small:

- `DataStore` — schema, persistence, seed data, audit and authentication
- `Security` — password hashing and security helpers
- `HotelMetrics` — operational KPI calculations
- `Ui` / `PremiumVisuals` — design system and reusable visual components
- domain Forms — reservations, rooms, guests, housekeeping, folio and administration
- intelligence Forms — Guest Intelligence 360° and Operations Command Center

New portfolio workspaces are implemented code-first to reduce fragile WinForms Designer coupling.

## Security

- PBKDF2-SHA256 password derivation with per-user salt
- fixed-time password-hash comparison
- authentication status checks
- audit entries for successful sign-in and operational actions
- automatic data backup during persistence

> Demo credentials: `admin` / `1234`  
> These credentials are intentionally for local portfolio demonstration only.

## Guest Intelligence 360°

The Guest Intelligence workspace combines guest identity, stay count, nights, recorded folio value and an automatically derived relationship tier. It gives front-desk staff a single view instead of forcing them to cross-reference several screens.

## Operations Command Center

The Operations Center turns raw operational data into an actionable daily view:

- hotel health score
- occupancy
- open housekeeping workload
- maintenance pressure
- prioritized attention queue

This is intentionally rule-based and explainable rather than pretending to be AI.

## UX principles

- dark navy/slate surfaces instead of harsh white operational screens
- blue for primary operational actions
- green for ready/healthy states
- amber for attention
- red only for maintenance/urgent states
- consistent typography and spacing
- RTL/LTR-aware alignment
- high information density without sacrificing scanability

## Run locally

1. Open `AshkanHotelManager.sln` in Visual Studio 2022.
2. Ensure **.NET Framework 4.8 Developer Pack** is installed.
3. Restore/build the solution.
4. Run the application.
5. Sign in with the demo account.

## Suggested demo flow

1. Sign in and show the premium dashboard.
2. Switch Persian ↔ English to demonstrate RTL/LTR behavior.
3. Open Room Status Board.
4. Create or inspect a reservation.
5. Open Guest Intelligence 360°.
6. Open Operations Command Center.
7. Show housekeeping and guest folio workflows.
8. Finish with Audit Log / system administration.

## Engineering decisions

This project intentionally remains on .NET Framework 4.8 because it represents modernization of an existing desktop application rather than a greenfield rewrite. The portfolio value is in incremental modernization: security, resilience, clean separation of reusable UI/business helpers, bilingual UX and operator-focused workflows.

## Roadmap

- migrate persistence to SQLite / EF Core in a future .NET desktop edition
- introduce automated tests around reservation conflict and KPI rules
- add role/permission policy editor
- add exportable PDF/Excel management reports
- add rate plans, channel/source tracking and revenue forecasting
- introduce API-backed multi-property synchronization

## Repository

Recommended repository name:

`AuroraStay-Hospitality-Operations-Suite`

Recommended GitHub description:

> Portfolio-grade bilingual hotel operations & property management suite in C#/.NET Framework 4.8 — Guest 360°, reservations, rooms, housekeeping, billing, operational intelligence, secure authentication and premium RTL/LTR desktop UX.

## License

Portfolio / educational demonstration. Add the license appropriate for your intended distribution before production use.
"# AuroraStay-Hospitality-Operations-Platform" 
