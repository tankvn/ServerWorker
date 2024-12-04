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

## Installing NLog

Install NLog nuget package for Windows Service .NET framework
- NLog is a logging platform for .NET with rich log routing and management capabilities.
- NLog supports traditional logging, structured logging and the combination of both.

Standard install
1. Install the latest NLog version 5.3.4 from [NuGet](https://www.nuget.org/packages/NLog/).
   - dotnet add package NLog --version 5.3.4
2. Setup initial NLog.config xml-file.
   - Choose "Add" > "New Item..."
   - In the "Add New Item" dialog, search for "XML File" or "XML" and select it.
   - Name the file NLog.config and click the "Add" button.
3. Set "Copy To Output Directory" to "Copy if newer" for the NLog.config.

That's it, you can now compile and run your application and it will be able to use NLog.

## Install the service

```bash
sc.exe create "Server Worker" binpath= "C:\Path\To\WindowsService.exe"
sc.exe create "Server Worker" binpath= "C:\Path\To\WindowsService.exe --contentRoot C:\Other\Path"
sc.exe start "Server Worker"
sc.exe stop "Server Worker"
sc.exe delete "Server Worker"
```

https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service