#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Dobany.Migrator/Dobany.Migrator.csproj", "src/Dobany.Migrator/"]
COPY ["src/Dobany.EntityFrameworkCore/Dobany.EntityFrameworkCore.csproj", "src/Dobany.EntityFrameworkCore/"]
COPY ["src/Dobany.Core/Dobany.Core.csproj", "src/Dobany.Core/"]
COPY ["src/Dobany.Core.Shared/Dobany.Core.Shared.csproj", "src/Dobany.Core.Shared/"]
RUN dotnet restore "src/Dobany.Migrator/Dobany.Migrator.csproj"
COPY . .
WORKDIR "/src/src/Dobany.Migrator"
RUN dotnet build "Dobany.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dobany.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dobany.Migrator.dll"]
