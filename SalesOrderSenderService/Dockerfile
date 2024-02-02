FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app

COPY SalesOrderSenderService.Worker/bin/Debug/net7.0 /app

#RUN ls /app

ENTRYPOINT ["dotnet", "SalesOrderSenderService.Worker.dll"]

