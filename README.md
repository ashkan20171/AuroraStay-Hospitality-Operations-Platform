# 🏨 AuroraStay Hotel Operations Platform

<p align="center">
  <strong>A modern bilingual hotel operations and property management desktop platform built with C# and .NET Framework 4.8.</strong>
</p>

<p align="center">
  Reservations • Guest 360° • Room Operations • Housekeeping • Billing • Operational Intelligence • Persian RTL • English LTR
</p>

---

## About AuroraStay

**AuroraStay Hotel Operations Platform** is a portfolio-grade desktop application designed to model real-world hotel operations through a unified and maintainable software solution.

Rather than focusing only on basic CRUD functionality, AuroraStay connects multiple operational workflows — including reservations, room status, housekeeping, guest information, billing, and operational monitoring — within a consistent desktop experience.

The project was built to demonstrate practical software engineering skills in:

- C# desktop application development
- Object-oriented design
- Business workflow modelling
- UI/UX engineering
- Localization and bidirectional interfaces
- Authentication and security concepts
- Data persistence and reliability
- Maintainable application architecture
- Operational dashboards and KPI presentation

The result is a hotel management platform that combines **business functionality, engineering structure, and user experience** in one portfolio project.

---

## ✨ Key Features

### 📊 Operations Dashboard

A centralized dashboard provides an overview of current hotel operations and important indicators.

It is designed to surface information such as:

- Occupancy status
- Available and occupied rooms
- Today's arrivals
- Today's departures
- Housekeeping workload
- Rooms requiring attention
- Revenue-related indicators
- Operational health

The objective is to give hotel staff useful information without requiring them to navigate through multiple screens.

---

### 🛎 Reservation Management

Manage the reservation lifecycle from a dedicated operational workspace.

Capabilities include:

- Create and manage reservations
- Assign guests and rooms
- Track arrival and departure dates
- Monitor reservation status
- Review reservation information
- Integrate reservations with room and guest operations

Reservation information is connected with other operational modules instead of being treated as isolated data.

---

### 🛏 Room Operations

The Room Board provides a visual representation of the hotel's current room state.

Room conditions can include:

- Available
- Reserved
- Occupied
- Cleaning required
- Operational attention required

Semantic visual indicators help users identify room status quickly and reduce unnecessary navigation.

---

### 🧹 Housekeeping Management

A dedicated housekeeping workspace supports daily room preparation and cleaning workflows.

It helps hotel staff identify rooms requiring attention and connects housekeeping activities with room and reservation states.

---

### 👤 Guest 360°

The **Guest 360°** workspace provides a consolidated view of guest information and activity.

Depending on available operational data, the workspace can present:

- Guest profile
- Stay history
- Number of stays
- Total nights
- Current reservations
- Guest tier
- Folio information
- Lifetime guest value
- Operational activity

The goal is to move beyond a simple guest list and provide a more meaningful view of the guest relationship.

---

### 💳 Guest Folio & Billing

The Guest Folio module provides a centralized view of guest-related financial activity.

It helps connect financial information with the guest's stay and operational context.

This includes concepts such as:

- Guest charges
- Folio activity
- Outstanding balances
- Stay-related financial information

---

### 🧠 Operations Command Center

AuroraStay includes an operational intelligence workspace designed to transform operational data into useful signals.

It brings together indicators such as:

- Occupancy pressure
- Arrivals and departures
- Housekeeping workload
- Open balances
- Rooms requiring attention
- Operational health

This demonstrates an important design principle of the project:

> Business software should not only store data — it should help users understand what requires attention.

---

## 🌍 True Bilingual & Bidirectional UX

AuroraStay supports:

**🇮🇷 Persian — RTL**

and

**🇬🇧 English — LTR**

Localization goes beyond translating labels.

The application adapts its interface direction and navigation structure according to the selected language.

### Persian Mode

- Persian user interface
- Right-to-left layout
- RTL-aware controls
- Navigation sidebar positioned on the **right**
- Persian-oriented alignment and flow

### English Mode

- English user interface
- Left-to-right layout
- LTR-aware controls
- Navigation sidebar positioned on the **left**
- English-oriented alignment and flow

A visible language switcher allows users to change the interface language directly from the application.

The selected language can also be preserved for subsequent sessions.

This implementation demonstrates practical handling of **internationalization (i18n)** and **bidirectional UI design**, where layout direction is treated as part of localization rather than an afterthought.

---

## 🎨 UI/UX Design

AuroraStay uses a custom visual language instead of relying entirely on default Windows Forms styling.

The interface follows a hospitality-inspired design system based on:

- Deep navy and slate surfaces
- Blue and teal operational accents
- Warm highlights
- Clear visual hierarchy
- Consistent spacing
- Information cards
- Semantic status indicators
- Readable operational tables
- Reduced visual noise
- High-contrast critical information

The design aims to demonstrate that enterprise desktop software can remain information-dense while still providing a modern and pleasant user experience.

---

## 🧩 Main Modules

| Module | Responsibility |
|---|---|
| Dashboard | Operational overview and KPIs |
| Reservations | Reservation lifecycle |
| Room Board | Room availability and status |
| Housekeeping | Cleaning and room preparation |
| Guest 360° | Guest profile and operational intelligence |
| Guest Folio | Guest financial activity |
| Calendar | Reservation timeline |
| Operations Center | Operational health and attention queue |
| Notifications | Operational information |
| Administration | Administrative functionality |
| Localization | Persian RTL / English LTR experience |

---

## 🏗️ Architecture & Engineering

AuroraStay has been progressively structured to keep application responsibilities understandable and maintainable.

The project separates concerns across areas such as:

```text
AuroraStay
│
├── UI
│   ├── Dashboard
│   ├── Reservations
│   ├── Rooms
│   ├── Housekeeping
│   ├── Guest 360
│   └── Operations Center
│
├── Application Logic
│   ├── Authentication
│   ├── Localization
│   ├── Operational Metrics
│   └── Business Workflows
│
├── Domain
│   ├── Guests
│   ├── Reservations
│   ├── Rooms
│   └── Financial Data
│
└── Persistence
    └── Local Data Storage
```

Newer workspaces favour programmatic WinForms composition where appropriate, reducing unnecessary dependence on large Designer-generated files.

The project emphasizes:

- Separation of concerns
- Reusable UI behaviour
- Centralized localization
- Defensive data handling
- Consistent navigation
- Maintainable event handling
- Clear naming
- Incremental refactoring

---

## 🔐 Authentication & Security

Security was considered as an engineering concern rather than only a login screen.

The project includes concepts such as:

- Salted password hashing
- PBKDF2-based password derivation
- Authentication separation
- Login auditing concepts
- Reduced plain-text credential exposure
- Defensive persistence behaviour

> **Note:** AuroraStay is a portfolio project. A dedicated security review, database-backed identity solution, secrets management strategy, and production infrastructure would be required before deployment in a real hotel environment.

Being explicit about this distinction is intentional: production readiness requires more than implementing authentication features.

---

## 💾 Data Reliability

The persistence layer includes defensive concepts intended to reduce accidental data corruption.

Examples include:

- Safer identifier generation
- Temporary-file write strategies
- Backup-oriented persistence
- Preservation of problematic data for diagnostics
- Separation of persistence concerns from UI logic

For a production evolution of the project, the local persistence layer could be replaced by a relational database such as **SQL Server or PostgreSQL** behind a dedicated data-access layer.

---

## 🛠️ Technology Stack

| Technology | Usage |
|---|---|
| C# | Primary programming language |
| .NET Framework 4.8 | Application runtime |
| Windows Forms | Desktop UI |
| XML / Local Persistence | Application data |
| PBKDF2 | Password derivation |
| SHA-256 | Cryptographic support |
| Visual Studio 2022 | Development environment |

---

## 🧠 Engineering Decisions

### Why Windows Forms?

The project intentionally demonstrates modernization of an established enterprise desktop technology.

Many internal business systems still depend on desktop applications, particularly where organizations require:

- Windows integration
- Local operation
- Existing .NET Framework infrastructure
- Incremental modernization
- Long-lived enterprise applications

AuroraStay demonstrates how such an application can be progressively improved without requiring an immediate rewrite into a completely different technology stack.

### Why true RTL/LTR switching?

Supporting Persian and English requires more than translating strings.

Navigation position, text alignment, control direction and visual flow must also adapt.

For this reason, AuroraStay treats bidirectional layout as an application-level concern.

### Why an Operations Command Center?

Traditional CRUD interfaces answer:

> “What data exists?”

Operational software should additionally answer:

> “What needs attention right now?”

The Command Center was introduced to demonstrate this distinction.

---

## 📸 Screenshots

> Screenshots can be added here to demonstrate the final UI.

Recommended screenshots:

1. Persian RTL Dashboard
2. English LTR Dashboard
3. Reservation Management
4. Room Operations
5. Guest 360°
6. Housekeeping
7. Operations Command Center
8. Language switching comparison

```text
docs/
└── screenshots/
    ├── dashboard-fa.png
    ├── dashboard-en.png
    ├── reservations.png
    ├── guest-360.png
    └── operations-center.png
```

---

## 🚀 Getting Started

### Requirements

- Windows 10 or Windows 11
- Visual Studio 2022
- .NET Framework 4.8 Developer Pack

### Installation

Clone the repository:

```bash
git clone https://github.com/YOUR-USERNAME/AuroraStay-Hotel-Operations-Platform.git
```

Open the solution in **Visual Studio 2022**.

Then:

```text
Build
└── Rebuild Solution
```

Run the application using:

```text
F5
```

For the first build after cloning, cleaning previous build artifacts is recommended if the project was copied from another environment.

---

## 🔄 Example User Journey

A typical workflow demonstrates how the modules work together:

```text
Login
   ↓
Operations Dashboard
   ↓
Create / Review Reservation
   ↓
Assign Guest & Room
   ↓
Monitor Room Status
   ↓
Housekeeping Workflow
   ↓
Guest 360°
   ↓
Guest Folio
   ↓
Operations Command Center
```

This workflow highlights the project's focus on connected business processes rather than isolated screens.

---

## 🗺️ Roadmap

Potential future improvements include:

- ASP.NET Core backend
- REST API
- SQL Server / PostgreSQL persistence
- Entity Framework Core
- Role-based authorization
- Multi-property hotel support
- Revenue management
- Rate plans
- Advanced reporting
- Audit trail
- Automated testing
- Dependency injection
- Cloud synchronization
- Dockerized backend services
- Web-based management portal
- Mobile housekeeping application
- External booking integrations
- CI/CD pipeline
- Automated release builds

A future architecture could evolve toward:

```text
Desktop Client
      │
      ▼
ASP.NET Core REST API
      │
      ├── Application Layer
      ├── Domain Layer
      └── Infrastructure Layer
                 │
                 ▼
          SQL Server / PostgreSQL
```

---

## 🎯 What This Project Demonstrates

AuroraStay was created as a portfolio project to demonstrate more than knowledge of C# syntax.

It demonstrates experience with:

**Software Engineering**

- Object-oriented programming
- Application architecture
- Refactoring
- Separation of concerns
- Maintainable code

**Business Applications**

- Workflow modelling
- Operational dashboards
- Data management
- Desktop enterprise software

**UI/UX**

- Information hierarchy
- Enterprise desktop design
- Semantic visual feedback
- Bidirectional interfaces
- Responsive layout thinking within desktop constraints

**Internationalization**

- Persian / English localization
- RTL / LTR switching
- Dynamic navigation direction
- Localized interface behaviour

**Security**

- Password derivation
- Salted credential storage concepts
- Authentication separation
- Defensive programming

---

## 🇪🇺 Portfolio Context

This repository is part of my software engineering portfolio and demonstrates my approach to building and improving real-world business applications.

I am particularly interested in software engineering opportunities involving:

- C# / .NET
- ASP.NET Core
- Business applications
- Enterprise software
- Backend development
- Full-stack development
- Software modernization

I value **clean code, maintainability, pragmatic engineering, thoughtful UI/UX, and continuous improvement**.

---

## 👨‍💻 Author

**Ashkan Motaei**

Software Engineer / C# & .NET Developer

GitHub: `@ashkan20171`

Open to international software engineering opportunities and relocation.

---

## ⭐ Final Note

AuroraStay represents an ongoing engineering exercise in turning a traditional desktop management application into a more structured, maintainable and user-focused software product.

The project intentionally combines:

**business workflows + software engineering + internationalization + security + UI/UX**

rather than treating them as unrelated concerns.

If you are reviewing this repository as part of a recruitment process, I recommend starting with the **Dashboard**, **Guest 360°**, **Operations Command Center**, and the **Persian RTL / English LTR switching experience**.
