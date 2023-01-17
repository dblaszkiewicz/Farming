FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Farming.Api/Farming.Api.csproj", "Farming.Api/"]
COPY ["Farming.Infrastructure/Farming.Infrastructure.csproj", "Farming.Infrastructure/"]
COPY ["Farming.Domain/Farming.Domain.csproj", "Farming.Domain/"]
COPY ["Farming.Shared.Abstractions/Farming.Shared.Abstractions.csproj", "Farming.Shared.Abstractions/"]
COPY ["Farming.Application/Farming.Application.csproj", "Farming.Application/"]
COPY ["Farming.Shared/Farming.Shared.csproj", "Farming.Shared/"]
RUN dotnet restore "Farming.Api/Farming.Api.csproj"
COPY . .
WORKDIR "/src/Farming.Api"
RUN dotnet build "Farming.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Farming.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Farming.Api.dll"]