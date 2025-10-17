function Test-NpmAvailable {
    <#
    .SYNOPSIS
    Checks if npm is available and optionally installs it via winget
    
    .DESCRIPTION
    This function checks if npm is available in the system PATH.
    If not found, it prompts the user to install npm via winget.
    #>
    
    try {
        $npmVersion = npm --version 2>$null
        if ($npmVersion) {
            return $true
        }
    }
    catch {
        # npm not found
    }
    
    Write-Host "npm is not available on this system." -ForegroundColor Red
    $response = Read-Host "Would you like to install npm via winget? (y/n)"

    if ($response.ToLower() -eq 'y' -or $response.ToLower() -eq 'yes') {
        Write-Host "Installing npm via winget..." -ForegroundColor DarkYellow
        try {
            winget install OpenJS.NodeJS
            Write-Host "npm installation completed." -ForegroundColor Green
            
            # Try to refresh PATH in current session
            $env:PATH = [System.Environment]::GetEnvironmentVariable("PATH", "Machine") + ";" + [System.Environment]::GetEnvironmentVariable("PATH", "User")
            
            # Test again
            $npmVersion = npm --version 2>$null
            if ($npmVersion) {
                Write-Host "npm is now available (version: $npmVersion)" -ForegroundColor Green
                return $true
            } else {
                Write-Host "npm was installed but is not immediately available. Please restart your terminal." -ForegroundColor DarkYellow
                return $false
            }
        }
        catch {
            Write-Host "Failed to install npm via winget: $_" -ForegroundColor Red
            return $false
        }
    }
    else {
        Write-Host "npm installation cancelled by user. Exiting." -ForegroundColor Red
        return $false
    }
}

function Copy-FilePairs {
    <#
    .SYNOPSIS
    Copies files and directories based on a list of source-destination pairs
    
    .DESCRIPTION
    Takes an array of hashtables, each containing 'Source' and 'Destination' keys,
    and copies each source file or directory to its corresponding destination.
    Handles both individual files and entire directory trees.
    
    .PARAMETER FilePairs
    Array of hashtables with 'Source' and 'Destination' keys
    #>
    
    param(
        [Parameter(Mandatory = $true)]
        [hashtable[]]$FilePairs
    )
    
    foreach ($pair in $FilePairs) {
        $source = $pair.Source
        $destination = $pair.Destination
        
        if (-not (Test-Path $source)) {
            continue
        }
        
        try {
            $sourceItem = Get-Item $source
            
            if ($sourceItem.PSIsContainer) {
                # Source is a directory
                Write-Host "Copying directory: $source -> $destination" -ForegroundColor Cyan
                
                # Create parent directory of destination if it doesn't exist
                $destParent = Split-Path $destination -Parent
                if ($destParent -and -not (Test-Path $destParent)) {
                    New-Item -ItemType Directory -Path $destParent -Force | Out-Null
                }
                
                # Copy directory recursively
                Copy-Item -Path $source -Destination $destination -Recurse -Force
                Write-Host "Directory copied successfully: $source -> $destination" -ForegroundColor Green
            }
            else {
                # Source is a file
                Write-Host "Copying file: $source -> $destination" -ForegroundColor Cyan
                
                # Create destination directory if it doesn't exist
                $destDir = Split-Path $destination -Parent
                if ($destDir -and -not (Test-Path $destDir)) {
                    New-Item -ItemType Directory -Path $destDir -Force | Out-Null
                }
                
                Copy-Item -Path $source -Destination $destination -Force
                Write-Host "File copied successfully: $source -> $destination" -ForegroundColor Green
            }
        }
        catch {
            Write-Host "Error copying $source to $destination : $_" -ForegroundColor Red
        }
    }
}

# Main script execution
Write-Host "Starting npm pack preparation script..." -ForegroundColor Cyan

# Check if npm is available
if (-not (Test-NpmAvailable)) {
    Write-Host ""
    Write-Host "Cannot proceed without npm. Exiting." -ForegroundColor Red
    Write-Host ""
    exit 1
}

### File copy for submodule contents to final package locations
# $filePairs = @(
#     @{ Source = ""; Destination = "" },
#     @{ Source = ""; Destination = "" }
# )
# Copy-FilePairs -FilePairs $filePairs

# Run npm pack
Write-Host "Running npm pack..." -ForegroundColor DarkYellow
try {
    npm pack
    Write-Host "npm pack completed successfully" -ForegroundColor Green
}
catch {
    Write-Host ""
    Write-Host "Error running npm pack: $_" -ForegroundColor Red
    Write-Host ""
    exit 1
}