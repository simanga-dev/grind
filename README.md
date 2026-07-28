# Comeback

A TikTok-style workout tracker for returning to training after a break.

## Stack

- **Backend**: .NET 10 API (Clean Architecture)
- **Frontend**: SvelteKit (mobile-first PWA)
- **Database**: PostgreSQL
- **Orchestration**: .NET Aspire

## Project Structure

```
src/
├── backend/           # .NET 10 API
│   ├── Comeback.Api/
│   ├── Comeback.Application/
│   ├── Comeback.Domain/
│   └── Comeback.Infrastructure/
└── frontend/          # SvelteKit app (to be added)
```

## Getting Started

```bash
# Backend
cd src/backend
dotnet restore
dotnet build

# Frontend (when added)
cd src/frontend
pnpm install
pnpm dev
```

## Features

- [ ] Exercise library with images
- [ ] TikTok-style vertical swipe navigation
- [ ] Set/rep tracking with tap-to-complete
- [ ] Progress persistence
- [ ] 4-week comeback program
