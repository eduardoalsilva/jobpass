# Contributing to JobPass

Thank you for contributing to JobPass.

This project follows a structured Git Flow strategy to ensure consistent and maintainable development.

---

## Branching Strategy

### Main Branches

- `main` → Production-ready code
- `develop` → Integration branch

### Supporting Branches

- `feature/*` → New features (from `develop`)
- `hotfix/*` → Production fixes (from `main`)
- `release/*` → Release preparation (from `develop`)

---

## Development Flow

1. Create a feature branch from `develop`:
```bash
git checkout develop
git pull
git checkout -b feature/short-description
```

2. Push your branch:
git push -u origin feature/short-description

3. Open a Pull Request targeting `develop`.

---

## Rules

- No direct commits to `main`
- All changes must go through Pull Requests
- Follow the defined branch naming convention
- Keep Pull Requests focused and small