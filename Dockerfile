FROM mcr.microsoft.com/dotnet/core/sdk

COPY WebAPIDemo/bin/Debug/netcoreapp2.2/publish/ .
WORKDIR .
EXPOSE 44370
ENTRYPOINT ["dotnet", "WebAPIDemo.dll","--urls=http://*:9898"]