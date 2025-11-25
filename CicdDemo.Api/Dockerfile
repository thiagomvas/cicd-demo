FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CicdDemo.Api/CicdDemo.Api.csproj", "CicdDemo.Api/"]
COPY ["CicdDemo.Core/CicdDemo.Core.csproj", "CicdDemo.Core/"]
RUN dotnet restore "CicdDemo.Api/CicdDemo.Api.csproj"
COPY . .
WORKDIR "/src/CicdDemo.Api"
RUN dotnet build "./CicdDemo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CicdDemo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CicdDemo.Api.dll"]
