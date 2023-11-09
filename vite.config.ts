import react from '@vitejs/plugin-react';
import type { UserConfig } from 'vite';
const config: UserConfig = ({
  plugins: [react()],
  publicDir: 'public',
  base: '/modules/helloModules/',
  server: {
    port: 30001,
    open: true,
    proxy1: {
      '^(?!/dist)': 'http://localhost:30000/',
      '/socket.io': {
        target: 'ws://localhost:30000',
        ws: true,
      },
    }
  },
  build: {
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
