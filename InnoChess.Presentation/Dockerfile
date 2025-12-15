FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InnoChess.Presentation/InnoChess.Presentation.csproj", "InnoChess.Presentation/"]
COPY ["InnoChess.Application/InnoChess.Application.csproj", "InnoChess.Application/"]
COPY ["InnoChess.Domain/InnoChess.Domain.csproj", "InnoChess.Domain/"]
COPY ["InnoChess.Infrastructure/InnoChess.Infrastructure.csproj", "InnoChess.Infrastructure/"]
RUN dotnet restore "InnoChess.Presentation/InnoChess.Presentation.csproj"
COPY . .
WORKDIR "/src/InnoChess.Presentation"
RUN dotnet build "./InnoChess.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InnoChess.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InnoChess.Presentation.dll"]
