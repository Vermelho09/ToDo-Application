FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["API/src/ToDo-API.Web/ToDo-API.Web.csproj", "API/src/ToDo-API.Web/"]
RUN dotnet restore "./API/src/ToDo-API.Web/ToDo-API.Web.csproj"
COPY . .
WORKDIR "/src/API/src/ToDo-API.Web"
RUN dotnet build "./ToDo-API.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ToDo-API.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDo-API.Web.dll"]

