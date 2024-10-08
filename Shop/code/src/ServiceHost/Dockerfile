FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["code/src/ServiceHost/ServiceHost.csproj", "code/src/ServiceHost/"]
COPY ["code/src/Domain/Shop.Domain/Shop.Domain.csproj", "code/src/Domain/Shop.Domain/"]
COPY ["code/src/Interface/Shop.RestApi/Shop.RestApi.csproj", "code/src/Interface/Shop.RestApi/"]
COPY ["code/src/Application/Shop.Application/Shop.Application.csproj", "code/src/Application/Shop.Application/"]
COPY ["code/src/Infrastructure/Shop.Infrastructure.Persistence.Sql/Shop.Infrastructure.Persistence.Sql.csproj", "code/src/Infrastructure/Shop.Infrastructure.Persistence.Sql/"]
COPY ["code/src/Infrastructure/Shop.Infrastructure/Shop.Infrastructure.csproj", "code/src/Infrastructure/Shop.Infrastructure/"]

RUN dotnet restore "code/src/ServiceHost/ServiceHost.csproj"
COPY . .
WORKDIR "/src/code/src/ServiceHost"
RUN dotnet build "ServiceHost.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ServiceHost.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceHost.dll"]
