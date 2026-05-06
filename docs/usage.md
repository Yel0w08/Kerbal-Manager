# KSP Launcher - User Guide

## Getting Started

### First Launch

1. Run `KSP-DL.exe`
2. The main launcher window appears with status information
3. If you have an `uncrypt_key` file, it will be detected automatically
4. Otherwise, place your key file in the launcher directory

### Decryption Key Setup

Create a file named `uncrypt_key` in the launcher directory:

```json
{
  "uncrypt_key": "YOUR_32_CHARACTER_KEY_HERE"
}
```

The key must be exactly 32 characters (letters and numbers only).

## Downloading KSP

1. Click **Get KSP** on the main launcher window
2. The download dialog opens
3. Select the game version (currently 1.12.5.3190)
4. Choose download format:
   - **SFX**: Self-extracting executable (easier, includes extractor)
   - **.7z**: 7-Zip archive parts (requires 7-Zip installed)
   - **CLEAN**: Remove downloaded archive files
5. Enter or verify your decryption key
6. Click **Download**
7. Wait for download and extraction to complete
8. Click **Launch KSP** when ready

### Download Progress

- Progress bar shows overall download status
- Status text shows current file being downloaded
- Click **Close** during download to cancel (download will be cleaned up)

## Launching the Game

### Direct Launch
- Click **Launch KSP** button
- Game launches directly if KSP_x64.exe is detected

### Open Game Folder
- Click **Open Game Folder** to browse installation files
- Useful for manual mod installation or configuration

## Managing Mods with CKAN

### What is CKAN?
CKAN (Comprehensive Kerbal Archive Network) is a mod manager for KSP, similar to Steam Workshop.

### First Time Setup
1. Click **Open CKAN (Mods)** on the main launcher
2. If CKAN is not found, choose "Yes" to download it
3. CKAN downloads to the launcher directory
4. CKAN launches automatically

### Using CKAN
- Browse available mods
- Install/remove mods with one click
- Manage mod dependencies automatically
- CKAN stores mods in your KSP installation folder

## Maintenance

### Clean Archive Files
- Click **Clean Archives** to remove downloaded .7z files
- Your extracted/installed game files are kept
- Frees up disk space after installation

### Open Download Folder
- Click **Open Download Folder** to browse the launcher directory
- View downloaded files, CKAN.exe, and game installations

### Refresh Status
- Click **Refresh Status** to update all status indicators
- Useful after manual changes to files

## Troubleshooting

### "KSP_x64.exe not found"
- Run a download first using **Get KSP**
- Check that extraction completed successfully
- Use **Open Game Folder** to verify installation

### "7z.exe was not found"
- Install 7-Zip from https://www.7-zip.org/
- Or use SFX format instead (no 7-Zip required)

### Key validation fails
- Ensure key is exactly 32 characters
- Only letters and numbers are allowed
- Check that `uncrypt_key` file is valid JSON
- Key is automatically normalized (spaces/special chars removed)

### Download fails
- Check internet connection
- Verify decryption key is correct
- Check available disk space
- Review error message in the dialog

## Tips

- Keep your `uncrypt_key` file safe and private
- Use SFX format for easiest installation
- Clean archives after successful installation to save space
- CKAN mods are stored in the KSP folder, not the launcher folder
- The launcher and game can be in the same directory for simplicity
