# AuroraStay — Bilingual RTL/LTR behavior

- First launch defaults to Persian (`fa`).
- Persian mode uses RTL and places the main sidebar on the right.
- English mode uses LTR and places the main sidebar on the left.
- Language changes rebuild the shell immediately; no application restart is required.
- The selected language is persisted in `app-language.txt` for subsequent launches.
- Direction is propagated through nested WinForms controls and DataGridView alignment.

## Verification points

`App.LoadSettings()` defaults to Persian when no settings file exists.
`MainForm.BuildShell()` explicitly docks the sidebar Right for Persian and Left for English.
`App.ApplyDirection()` recursively applies RTL/LTR to child controls.
