param(
    [string]$Message = "Checkpoint"
)

function Git-CommitAndPush {
    param($msg)
    git add -A
    $now = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
    git commit -m "$msg - $now"
    git push origin main
}

if (-not (Test-Path -Path ".git")) {
    Write-Error "This folder is not a git repository. Run the script from the project folder."
    exit 1
}

if ($Message -eq 'Checkpoint') { $Message = 'Checkpoint commit' }
Git-CommitAndPush -msg $Message
