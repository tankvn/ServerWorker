using ServerWorker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = ".NET Worker Service";
});
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
