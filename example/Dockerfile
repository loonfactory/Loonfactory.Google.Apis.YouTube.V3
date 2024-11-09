FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5193

ENV ASPNETCORE_URLS=http://+:5193

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["example/Loonfactory.Google.Apis.YouTube.V3.Example.csproj", "example/"]
RUN dotnet restore "example/Loonfactory.Google.Apis.YouTube.V3.Example.csproj"
COPY . .
WORKDIR "/src/example"
RUN dotnet build "Loonfactory.Google.Apis.YouTube.V3.Example.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Loonfactory.Google.Apis.YouTube.V3.Example.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Loonfactory.Google.Apis.YouTube.V3.Example.dll"]
