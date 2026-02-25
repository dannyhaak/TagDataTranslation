#!/usr/bin/env python3
"""Build script for the tag-data-translation pip package.

Compiles the .NET library and copies the output DLLs into the package
so they ship alongside the Python wrapper.
"""

import shutil
import subprocess
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent.parent
CSPROJ = ROOT / "src" / "TagDataTranslation" / "TagDataTranslation.csproj"
DEST = Path(__file__).resolve().parent.parent / "src" / "tag_data_translation" / "dotnet"

# build for net8.0 — widest runtime compatibility
FRAMEWORK = "net8.0"


def main() -> None:
    print(f"Building TagDataTranslation ({FRAMEWORK})...")
    subprocess.run(
        [
            "dotnet", "build", str(CSPROJ),
            "-c", "Release",
            "-f", FRAMEWORK,
            # override TargetFrameworks to avoid needing MAUI workloads on CI
            f"/p:TargetFrameworks={FRAMEWORK}",
        ],
        check=True,
    )

    publish_dir = (
        ROOT / "src" / "TagDataTranslation" / "bin" / "Release" / FRAMEWORK
    )
    if not publish_dir.exists():
        print(f"Build output not found: {publish_dir}", file=sys.stderr)
        sys.exit(1)

    # clean and recreate destination
    if DEST.exists():
        shutil.rmtree(DEST)
    DEST.mkdir(parents=True)

    # copy DLLs and JSON config files (skip PDBs and XML docs)
    skip_extensions = {".pdb", ".xml"}
    copied = 0
    for f in publish_dir.iterdir():
        if f.is_file() and f.suffix not in skip_extensions:
            shutil.copy2(f, DEST / f.name)
            copied += 1

    # copy license
    license_src = ROOT / "LICENSING.md"
    license_dst = Path(__file__).resolve().parent.parent / "LICENSE.md"
    shutil.copy2(license_src, license_dst)

    print(f"Build complete. Copied {copied} files to {DEST}")


if __name__ == "__main__":
    main()
