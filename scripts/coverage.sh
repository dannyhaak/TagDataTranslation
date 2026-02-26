#!/bin/bash
# generate test coverage report for TagDataTranslation
set -e

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
ROOT_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
TEST_PROJECT="$ROOT_DIR/test/TagDataTranslation.Tests/TagDataTranslation.Tests.csproj"
RESULTS_DIR="$ROOT_DIR/coveragereport"

# ensure reportgenerator is installed
if ! dotnet tool list -g | grep -q reportgenerator; then
    echo "Installing dotnet-reportgenerator-globaltool..."
    dotnet tool install -g dotnet-reportgenerator-globaltool
fi

# clean previous results
rm -rf "$ROOT_DIR/test/TagDataTranslation.Tests/TestResults"
rm -rf "$RESULTS_DIR"

# run tests with coverage collection
echo "Running tests with coverage..."
dotnet test "$TEST_PROJECT" \
    --collect:"XPlat Code Coverage" \
    --results-directory "$ROOT_DIR/test/TagDataTranslation.Tests/TestResults"

# find the coverage file
COVERAGE_FILE=$(find "$ROOT_DIR/test/TagDataTranslation.Tests/TestResults" -name "coverage.cobertura.xml" | head -1)

if [ -z "$COVERAGE_FILE" ]; then
    echo "Error: no coverage file found"
    exit 1
fi

# generate HTML report
echo "Generating HTML report..."
reportgenerator \
    -reports:"$COVERAGE_FILE" \
    -targetdir:"$RESULTS_DIR" \
    -reporttypes:Html

echo ""
echo "Coverage report: $RESULTS_DIR/index.html"

# open report on macOS
if command -v open &> /dev/null; then
    open "$RESULTS_DIR/index.html"
fi
