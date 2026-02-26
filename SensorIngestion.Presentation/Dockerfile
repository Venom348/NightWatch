FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SensorIngestion.Presentation/SensorIngestion.Presentation.csproj", "SensorIngestion.Presentation/"]
RUN dotnet restore "SensorIngestion.Presentation/SensorIngestion.Presentation.csproj"
COPY . .
WORKDIR "/src/SensorIngestion.Presentation"
RUN dotnet build "./SensorIngestion.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SensorIngestion.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SensorIngestion.Presentation.dll"]
