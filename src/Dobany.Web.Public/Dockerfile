#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Dobany.Web.Public/Dobany.Web.Public.csproj", "src/Dobany.Web.Public/"]
COPY ["src/Dobany.Web.Core/Dobany.Web.Core.csproj", "src/Dobany.Web.Core/"]
COPY ["src/Dobany.Application/Dobany.Application.csproj", "src/Dobany.Application/"]
COPY ["src/Dobany.Application.Shared/Dobany.Application.Shared.csproj", "src/Dobany.Application.Shared/"]
COPY ["src/Dobany.Core.Shared/Dobany.Core.Shared.csproj", "src/Dobany.Core.Shared/"]
COPY ["src/Dobany.Core/Dobany.Core.csproj", "src/Dobany.Core/"]
COPY ["src/Dobany.EntityFrameworkCore/Dobany.EntityFrameworkCore.csproj", "src/Dobany.EntityFrameworkCore/"]
COPY ["src/Dobany.GraphQL/Dobany.GraphQL.csproj", "src/Dobany.GraphQL/"]
RUN dotnet restore "src/Dobany.Web.Public/Dobany.Web.Public.csproj"
COPY . .
WORKDIR "/src/src/Dobany.Web.Public"
RUN dotnet build "Dobany.Web.Public.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dobany.Web.Public.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dobany.Web.Public.dll"]
