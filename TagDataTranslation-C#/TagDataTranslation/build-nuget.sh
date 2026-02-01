#!/bin/bash
# Build and optionally publish TagDataTranslation NuGet package

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR"

# clean previous builds
rm -rf bin/Release obj

echo "Building TagDataTranslation..."
dotnet build -c Release

echo "Creating NuGet package..."
dotnet pack -c Release --no-build

PACKAGE=$(ls bin/Release/*.nupkg | head -1)
echo ""
echo "Package created: $PACKAGE"
echo ""

# show package contents
echo "Package contents:"
dotnet nuget inspect "$PACKAGE" 2>/dev/null || unzip -l "$PACKAGE" | head -30

echo ""
echo "To publish to NuGet.org:"
echo "  dotnet nuget push \"$PACKAGE\" --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json"
echo ""
echo "To publish to a local feed:"
echo "  dotnet nuget push \"$PACKAGE\" --source /path/to/local/feed"
