using SalesOrderSenderService.Infra.IoC;
using SalesOrderSenderService.Worker;
using Serilog;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddInfrastructure(hostContext.Configuration);
        services.AddInfrastructureSerilog(hostContext.Configuration);
        services.AddHostedService<SalesOrderSenderServiceWorker>();        
    })  
    .UseSerilog()
    .UseWindowsService()
    .Build();

host.Run();
