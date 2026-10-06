# Security Notes

- Passwords are not stored in plaintext.
- Authentication uses PBKDF2-SHA256 with per-user salts.
- Hash comparison uses a fixed-time comparison helper.
- Successful sign-ins are audited.
- Local data writes preserve a backup and corrupted files are retained for diagnosis.

The bundled `admin / 1234` account is a portfolio demo credential and must be changed or removed before any production deployment.
