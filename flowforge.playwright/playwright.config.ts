import { defineConfig } from '@playwright/test';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const rootDir = path.dirname(fileURLToPath(import.meta.url));
const externalBase = process.env.PLAYWRIGHT_BASE_URL;

export default defineConfig({
  testDir: 'tests/e2e',
  timeout: 60_000,
  use: {
    baseURL: externalBase ?? 'http://127.0.0.1:4173',
    viewport: { width: 1920, height: 1080 },
    screenshot: 'on',
    trace: 'retain-on-failure',
    video: 'off',
    launchOptions: {
      args: ['--no-sandbox', '--disable-setuid-sandbox'],
      chromiumSandbox: false
    }
  },
  projects: [
    {
      name: 'firefox',
      use: { browserName: 'firefox' }
    }
  ],
  webServer: externalBase
    ? undefined
    : {
        command: 'npm --prefix ../flowforge.ui run preview -- --host 127.0.0.1 --port 4173',
        port: 4173,
        reuseExistingServer: true,
        cwd: rootDir
      }
});
