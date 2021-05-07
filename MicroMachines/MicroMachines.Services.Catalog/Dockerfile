#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MicroMachines.Services.Catalog/MicroMachines.Services.Catalog.csproj", "MicroMachines.Services.Catalog/"]
RUN dotnet restore "MicroMachines.Services.Catalog/MicroMachines.Services.Catalog.csproj"
COPY . .
WORKDIR "/src/MicroMachines.Services.Catalog"
RUN dotnet build "MicroMachines.Services.Catalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroMachines.Services.Catalog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroMachines.Services.Catalog.dll"]
