Playwright E2E suite for Flowforge UI
======================================

Struktura
---------
- `playwright.config.ts` – konfiguracja runnera (katalog tests/e2e, domyślny viewport 1920x1080).
- `tests/e2e/` – testy i mocki API.
- `tests/e2e/artifacts/` – zrzuty ekranu i wygenerowane PDF-y (light/dark).

Uruchomienie lokalne
-------------------
1. Uruchom podgląd UI (w repo głównym):
   `npm --prefix flowforge.ui run preview -- --host 127.0.0.1 --port 4174`
2. W katalogu `flowforge.playwright` odpal:
   `PLAYWRIGHT_BASE_URL=http://127.0.0.1:4174 npx playwright test --project=firefox`

Artefakty
---------
- Zrzuty PNG: `tests/e2e/artifacts/light/` oraz `tests/e2e/artifacts/dark/`.
- Prezentacje: `presentation-light.pdf` i `presentation-dark.pdf` w katalogu artifacts.

Instalacja zależności
---------------------
`npm install`

