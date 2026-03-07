Flowforge — instrukcja uruchomienia
===================================

Wymagania wstępne
-----------------
- Node.js ≥ 18 (frontend, Playwright)
- .NET SDK 8 (API i testy NUnit)
- npm

Struktura projektu
------------------
- `flowforge.api/` — ASP.NET Core Web API
- `flowforge.ui/` — Vite + React (frontend)
- `flowforge.nunit/` — testy jednostkowe NUnit
- `flowforge.playwright/` — testy E2E (Playwright) + zrzuty ekranów i prezentacje

Uruchomienie API (dev)
----------------------
```bash
dotnet build Flowforge.sln
dotnet run --project flowforge.api/Flowforge.Api.csproj
```
Domyślnie używa lokalnej bazy SQLite (`flowforge.api/flowforge.db`).

Uruchomienie frontendu (dev)
----------------------------
```bash
npm --prefix flowforge.ui install
npm --prefix flowforge.ui run dev
```
Lub podgląd builda:
```bash
npm --prefix flowforge.ui run build
npm --prefix flowforge.ui run preview -- --host 127.0.0.1 --port 4174
```

Testy NUnit
-----------
```bash
dotnet test flowforge.nunit/Flowforge.NUnit.csproj
```

Testy Playwright (E2E)
----------------------
Katalog: `flowforge.playwright`
```bash
npm install              # jednorazowo
npm test                 # Playwright (firefox) + auto-start preview frontu
npm run render           # buduje PDF (light/dark) z aktualnych zrzutów, sprząta pliki pomocnicze
npm run docs             # testy E2E + PDF, kopiuje presentation-light/dark.pdf do latex/
```
Artefakty (zrzuty + PDF): `flowforge.playwright/tests/e2e/artifacts/`.

Porządkowanie i cache
---------------------
- Logi/artefakty Playwright ignorowane w `.gitignore`.
- Jeśli npm zgłasza problemy z integralnością, wyczyść cache: `npm cache clean --force`.

Przydatne komendy skrótowe
--------------------------
- Build całości: `dotnet build Flowforge.sln`
- Lint frontu: `npm --prefix flowforge.ui run lint`
- Lista testów E2E: `npx playwright test --project=firefox --list` (w `flowforge.playwright`)

Uwagi
-----
- Wszystkie komendy zakładają katalog roboczy w root repo.
- API i UI domyślnie nasłuchują lokalnie; Playwright używa portu 4173 (auto) lub 4174, jeśli wskazany `PLAYWRIGHT_BASE_URL`.
