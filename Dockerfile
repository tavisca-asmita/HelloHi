FROM mcr.microsoft.com/dotnet/core/sdk

COPY WebAPIDemo/bin/Debug/netcoreapp2.2/publish/ .
WORKDIR .
EXPOSE 6001
ENTRYPOINT ["dotnet", "WebAPIDemo.dll"]