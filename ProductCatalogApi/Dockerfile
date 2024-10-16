# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ProductCatalogApi.csproj", "./"]
RUN dotnet restore "ProductCatalogApi.csproj"
COPY . .
RUN dotnet build "ProductCatalogApi.csproj" -c Release -o /app/build
RUN dotnet publish "ProductCatalogApi.csproj" -c Release -o /app/publish

# Use the runtime image to serve the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProductCatalogApi.dll"]
