# Grind

TikTok-style workout tracker for returning to training after a break. Swipe through exercises, tap to complete sets, track your grind back to peak form.

## Stack

- **Backend**: .NET 10 API (Clean Architecture)
- **Frontend**: SvelteKit (mobile-first PWA)
- **Database**: PostgreSQL
- **Orchestration**: .NET Aspire

## Project Structure

```
src/
├── backend/           # .NET 10 API
│   ├── Grind.Api/
│   ├── Grind.Application/
│   ├── Grind.Domain/
│   └── Grind.Infrastructure/
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
- [ ] Dark gym-friendly UI
