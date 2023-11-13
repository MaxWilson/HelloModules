import react from '@vitejs/plugin-react';
import type { UserConfig } from 'vite';

// during development, you should point your browser to localhost:30001 (vite dev server) and not Foundry's server on localhost:30000, which will be used
// under the hood for everything except the module itself. This way vite dev server can make sure that react is loaded properly, hot loading works, etc.
// In production everything will be bundled using rollup and you will interact with Foundry normally.

const config: UserConfig = ({
  plugins: [react()],
  publicDir: 'public',
  base: '/modules/helloModules/',
  server: {
    port: 30001,
    open: './index.html', // necessary to "wake up" the react plugin so it will rewrite Program.js
    proxy: {
      '^(?!/modules/helloModules/.*)': 'http://localhost:30000/',
      '/socket.io': {
        target: 'ws://localhost:30000',
        ws: true,
      },
    }
  },
  build: {
    manifest: true,
    outDir: 'dist',
    emptyOutDir: true,
    sourcemap: true,
    lib: {
      name: 'helloModules',
      entry: 'dist/Program.js',
      formats: ['es'],
      fileName: 'Program'
    }
  },
})

export default config;
