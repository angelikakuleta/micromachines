#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MicroMachines.Services.Identity/MicroMachines.Services.Identity.csproj", "MicroMachines.Services.Identity/"]
RUN dotnet restore "MicroMachines.Services.Identity/MicroMachines.Services.Identity.csproj"
COPY . .
WORKDIR "/src/MicroMachines.Services.Identity"
RUN dotnet build "MicroMachines.Services.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroMachines.Services.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroMachines.Services.Identity.dll"]
