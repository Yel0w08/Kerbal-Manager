# KSP Launcher - Architecture

## Overview

KSP Launcher is a .NET 10 Windows Forms application that serves as a game launcher, download manager, and mod manager for Kerbal Space Program.

## Project Structure

### Core Services

**Constants.cs**
- Central location for shared constants
- Repository information (owner, name, commit hash)
- Supported game versions
- Archive file names
- CKAN download URL

**KspDownloadService.cs**
- Handles all download operations from GitHub archive
- Manages download progress reporting
- Key normalization and validation
- URL building for GitHub raw content

**ArchiveExtractor.cs**
- Handles extraction of downloaded archives
- Supports Self-Extracting (SFX) executables
- Supports 7-Zip archive extraction
- Locates 7-Zip installation automatically

**LauncherEnvironment.cs**
- File system operations and path resolution
- Decryption key file reading (JSON format)
- KSP executable detection
- Archive artifact management

### UI Forms

**LauncherForm.cs**
- Main application window
- Game launch and status display
- CKAN mod manager integration
- Download folder management
- Archive cleanup utilities

**DownloadForm.cs**
- Download dialog for KSP builds
- Version and format selection
- Progress tracking with cancellation support
- Automatic key detection and validation
- Post-download extraction handling

### Entry Point

**Program.cs**
- Application bootstrap
- Sets up Windows Forms configuration
- Launches LauncherForm as main window

## Data Flow

### Download Flow
1. User clicks "Get KSP" on LauncherForm
2. DownloadForm opens as dialog
3. User selects version and format
4. Key is loaded automatically or entered manually
5. KspDownloadService downloads files from GitHub archive
6. ArchiveExtractor handles extraction (SFX or 7z)
7. LauncherEnvironment detects installed game
8. LauncherForm updates status and enables launch

### Launch Flow
1. LauncherEnvironment.FindKspExecutable() locates KSP_x64.exe
2. LauncherForm updates UI with game status
3. User clicks "Launch KSP"
4. Process.Start() launches the game executable

### Mod Management Flow
1. LauncherForm checks for CKAN.exe in common locations
2. If not found, offers to download from GitHub releases
3. User clicks "Open CKAN" to launch mod manager
4. CKAN manages mod installations separately

## Key Design Decisions

**Separation of Concerns**
- UI logic separated from business logic
- Download operations abstracted into KspDownloadService
- Extraction logic isolated in ArchiveExtractor
- Environment/path helpers in LauncherEnvironment

**Error Handling**
- Try-catch patterns with user-friendly MessageBox notifications
- Graceful degradation when optional components missing
- Cancellation support for long-running downloads

**Security**
- 32-character encryption keys for archive access
- Keys loaded from local JSON file (uncrypt_key)
- No network transmission of keys
- Private archive server for personal backups only

## Dependencies

- .NET 10.0 Windows Desktop SDK
- System.Text.Json for key file parsing
- System.Net.Http for downloads
- Windows Forms (WinForms) for UI
- (Optional) 7-Zip for .7z archive extraction
