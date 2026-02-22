#!/bin/bash
set -euo pipefail

# Build WASM and publish the @mimasu/tdt npm package.
# Prerequisites:
#   - .NET 8 SDK with wasm-tools workload (dotnet workload install wasm-tools)
#   - Node.js 18+
#   - npm login (or NPM_TOKEN environment variable)
#
# Usage: ./scripts/publish-npm.sh [--dry-run]

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
ROOT_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
NPM_DIR="$ROOT_DIR/npm"
DRY_RUN=""

if [[ "${1:-}" == "--dry-run" ]]; then
    DRY_RUN="--dry-run"
    echo "=== DRY RUN MODE ==="
    echo ""
fi

echo "=== Building TagDataTranslation WASM ==="
node "$NPM_DIR/scripts/build.js"
echo ""

echo "=== Running smoke test ==="
node "$NPM_DIR/test/smoke.js"
echo ""

echo "=== Publishing to npm ==="
cd "$NPM_DIR"
npm publish --access public $DRY_RUN
echo ""

if [[ -z "$DRY_RUN" ]]; then
    echo "=== Published successfully ==="
    echo "Package: @mimasu/tdt@$(node -p "require('./package.json').version")"
    echo "https://www.npmjs.com/package/@mimasu/tdt"
else
    echo "=== Dry run complete (nothing published) ==="
fi
