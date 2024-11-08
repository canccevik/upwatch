module.exports = {
  parser: '@typescript-eslint/parser',
  parserOptions: {
    project: './tsconfig.json',
    tsconfigRootDir: __dirname,
    sourceType: 'module'
  },
  plugins: ['@typescript-eslint/eslint-plugin'],
  extends: [
    '@upwatch/eslint-config',
    'plugin:@typescript-eslint/recommended',
    'plugin:prettier/recommended'
  ]
}
