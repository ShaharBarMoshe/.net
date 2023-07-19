FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80/tcp

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Playlist.API.csproj", "./"]
RUN dotnet restore "Playlist.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Playlist.API.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Playlist.API.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Playlist.API.dll"]