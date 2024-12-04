# ServerWorker
Windows service app runs on schedule

## Create a new project

1. From the Visual Studio **File** menu, select **New > Project** (or press `Ctrl`+`Shift`+`N`) to open the **New Project** window.
2. Find and select the **Worker Service** project template.
3. For Project name, enter **ServerWorker**, and then select Create.

```bash
dotnet new worker --name ServerWorker --framework net8.0
dotnet add package Microsoft.Extensions.Hosting.WindowsServices
dotnet add package Microsoft.Extensions.Hosting.WindowsServices --version 8.0.1
dotnet run
dotnet publish --output "C:\custom\publish\directory"
```

## Install the service

```bash
sc.exe create "Server Worker" binpath= "C:\Path\To\WindowsService.exe"
sc.exe create "Server Worker" binpath= "C:\Path\To\WindowsService.exe --contentRoot C:\Other\Path"
sc.exe start "Server Worker"
sc.exe stop "Server Worker"
sc.exe delete "Server Worker"
```

https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service