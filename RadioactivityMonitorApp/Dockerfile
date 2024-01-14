FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RadioactivityMonitorApp/RadioactivityMonitorApp.csproj", "RadioactivityMonitorApp/"]
COPY ["RadioactivityMonitor/RadioactivityMonitor.csproj", "RadioactivityMonitorApp/"]
RUN dotnet restore "RadioactivityMonitorApp/RadioactivityMonitorApp.csproj"
COPY . .
WORKDIR "/src/RadioactivityMonitorApp"
RUN dotnet build "RadioactivityMonitorApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "RadioactivityMonitorApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RadioactivityMonitorApp.dll"]
