# KSP Launcher & Downloader

A specialized launcher and download manager for Kerbal Space Program (KSP). This tool provides a streamlined way to download, install, and launch KSP from archived builds, plus manage mods with CKAN.

## Features

**Game Management**
- Download archived KSP builds (1.12.5.3190) from a private archive server
- Automatic decryption key loading from `uncrypt_key` JSON file
- Multiple download formats: Self-Extracting (.exe) or 7-Zip archive parts
- Automatic extraction and installation
- Direct game launching from the launcher

**Mod Support**
- Integrated CKAN (Comprehensive Kerbal Archive Network) mod manager
- One-click CKAN download and launch
- Mod installation management

**User Experience**
- Clean, modern Windows Forms UI
- Download progress tracking
- Automatic detection of installed game files
- Archive cleanup utilities

## Legal Disclaimer

This project is strictly intended for **personal backup purposes only**.

- **No Piracy**: This tool does not facilitate unauthorized sharing of copyrighted material
- **Ownership Required**: Users must own a legitimate, paid license of Kerbal Space Program
- **Secure Backups**: All archive files are protected by 32-character encryption keys
- **Private Archive**: The archive server acts as secure, private storage for personal backups

## Quick Start

1. Place your `uncrypt_key` file in the launcher directory:
   ```json
   {
     "uncrypt_key": "YOUR_32_CHARACTER_KEY_HERE"
   }
   ```

2. Launch `KSP-DL.exe`
3. Click **Get KSP** to download and install the game
4. Use **Launch KSP** to start playing
5. Click **Open CKAN** to manage mods

## Architecture

```
KSP-DL/
├── Program.cs                 # Application entry point
├── Constants.cs               # Shared constants and configuration
├── KspDownloadService.cs      # Download logic and key normalization
├── ArchiveExtractor.cs        # 7z/SFX extraction handling
├── LauncherEnvironment.cs     # File system and environment helpers
├── LauncherForm.cs            # Main launcher UI
├── DownloadForm.cs            # Download dialog UI
└── docs/                     # Documentation
    ├── architecture.md        # System design
    └── usage.md              # User guide
```

## Requirements

- Windows 10/11
- .NET 10.0 Runtime
- (Optional) 7-Zip installed for .7z archive extraction

## Building

```bash
dotnet build KSP-DL.csproj
```

## Contact

For technical issues or inquiries: PikminTea@proton.me

---
*Last updated: 2026*
