# Portfolio Release Notes

## Quality improvements
- Replaced hard-coded credential comparison with a user table and PBKDF2-SHA256 verification.
- Added fixed-time hash comparison and login audit events.
- Made record IDs monotonic instead of relying on row count, preventing duplicate IDs after deletion.
- Added safer persistence: write-to-temp + previous-file backup, plus corrupt-file preservation during startup recovery.
- Extracted hotel KPI calculations from the main form into `HotelMetrics`.
- Kept the existing bilingual RTL/LTR behavior and centralized UI styling.
- Updated the shell to show the authenticated role instead of a hard-coded Admin label.

## Recommended production evolution
The current XML/DataSet persistence is intentionally zero-dependency and portfolio-friendly. A real multi-user hotel deployment should move persistence and identity to a transactional server database, use granular authorization, centralized backups, concurrency controls, structured logging, automated tests and CI/CD.
