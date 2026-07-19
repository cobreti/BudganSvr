<#
.SYNOPSIS
    Starts a SQL Server (MSSQL) Docker container with port forwarding.

.PARAMETER Password
    Password for the login. Must satisfy SQL Server complexity rules
    (8+ chars, upper+lower+digit or symbol). Also used as the SA password internally
    when -Username is not "sa".

.PARAMETER Username
    SQL login to connect with. Defaults to "sa". If set to anything else, a new SQL
    login with that name is created (with sysadmin rights) after the container starts.

.PARAMETER Port
    Host port to forward to the container's 1433 port. Defaults to 1433.

.PARAMETER ContainerName
    Name for the Docker container. Defaults to "budgan-mssql".

.PARAMETER Image
    MSSQL Docker image to use. Defaults to "mcr.microsoft.com/mssql/server:2022-latest".

.EXAMPLE
    ./Start-MssqlContainer.ps1 -Password "YourStr0ng!Pass"

.EXAMPLE
    ./Start-MssqlContainer.ps1 -Password "YourStr0ng!Pass" -Username "budgan_user" -Port 14330 -ContainerName "budgan-mssql-dev"
#>

param(
    [Parameter(Mandatory = $true)]
    [string]$Password,

    [string]$Username = "sa",

    [int]$Port = 1433,

    [string]$ContainerName = "budgan-mssql",

    [string]$Image = "mcr.microsoft.com/mssql/server:2022-latest"
)

$ErrorActionPreference = "Stop"

$existing = docker ps -a --filter "name=^/$ContainerName$" --format "{{.Names}}"
if ($existing -eq $ContainerName) {
    Write-Host "Container '$ContainerName' already exists. Starting it..."
    docker start $ContainerName
    exit 0
}

Write-Host "Pulling image '$Image'..."
docker pull $Image

Write-Host "Starting container '$ContainerName' on port $Port..."
docker run -d `
    --name $ContainerName `
    -e "ACCEPT_EULA=Y" `
    -e "MSSQL_SA_PASSWORD=$Password" `
    -p "${Port}:1433" `
    $Image

if ($Username -ne "sa") {
    Write-Host "Waiting for SQL Server to become ready..."
    $ready = $false
    for ($i = 0; $i -lt 30; $i++) {
        Start-Sleep -Seconds 2
        docker exec $ContainerName /opt/mssql-tools18/bin/sqlcmd -C -S localhost -U sa -P $Password -Q "SELECT 1" *> $null
        if ($LASTEXITCODE -eq 0) {
            $ready = $true
            break
        }
    }

    if (-not $ready) {
        throw "SQL Server did not become ready in time; login '$Username' was not created."
    }

    Write-Host "Creating login '$Username'..."
    $createLoginSql = "IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = '$Username') BEGIN CREATE LOGIN [$Username] WITH PASSWORD = '$Password'; ALTER SERVER ROLE sysadmin ADD MEMBER [$Username]; END"
    docker exec $ContainerName /opt/mssql-tools18/bin/sqlcmd -C -S localhost -U sa -P $Password -Q $createLoginSql

    Write-Host "Container '$ContainerName' started. Connect on localhost,$Port with user '$Username'."
} else {
    Write-Host "Container '$ContainerName' started. Connect on localhost,$Port with user 'sa'."
}