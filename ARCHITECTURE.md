# Architecture

AuroraStay uses a pragmatic layered WinForms structure: persistence/authentication in `DataStore`, security primitives in `Security`, KPI rules in `HotelMetrics`, reusable styling in `Ui` and `PremiumVisuals`, and workflow-specific Forms. Portfolio intelligence workspaces are code-first Forms to minimize Designer fragility.

## Data flow

UI → workflow/domain rules → DataStore → local XML + backup.

## Modernization strategy

The project demonstrates incremental modernization of a legacy-style desktop application without hiding the trade-offs of .NET Framework 4.8 or local XML persistence.
