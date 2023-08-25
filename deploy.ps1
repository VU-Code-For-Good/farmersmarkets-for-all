# Import the Posh-SSH module
Import-Module Posh-SSH -Scope Local -Force

# Remote server details
$RemoteFarmersUser = "farmersMarketAdmin"
$RemoteFarmersHost = "20.228.226.238"
$RemoteFarmersPort = "22"
$RemoteFarmersPassword = "96r8BrCljD%e"

# Commands to execute remotely
$Commands = @(
    "sudo caddy stop",
    "sudo docker stop cfa-farmers-backend",
    "sudo docker rm cfa-farmers-backend",
    "sudo docker run -d -p 8080:80 --name cfa-farmers-backend ghcr.io/vu-code-for-good/farmersmarkets-for-all:main",
    "sudo docker stop cfa-farmers-frontend",
    "sudo docker rm cfa-farmers-frontend",
    "sudo docker run -d -p 8090:80 --name cfa-farmers-frontend ghcr.io/vu-code-for-good/farmersmarkets-for-all-frontend:main",
    "sudo caddy start",
    "sudo docker ps"
)

# Establish an SSH session
$session = New-SSHSession -ComputerName $RemoteFarmersHost -Port $RemoteFarmersPort -Credential (New-Object PSCredential($RemoteFarmersUser, (ConvertTo-SecureString $RemoteFarmersPassword -AsPlainText -Force))) -AcceptKey:$true

# Execute the remote commands
foreach ($command in $Commands) {
    $result = Invoke-SSHCommand -SessionId $session.SessionId -Command $command
    Write-Host "Output from '$command': $($result.Output)"
}

# Close the SSH session
Remove-SSHSession -SessionId $session.SessionId
