# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["OrderManagementApi.csproj", "./"]
RUN dotnet restore "OrderManagementApi.csproj"
COPY . .
RUN dotnet build "OrderManagementApi.csproj" -c Release -o /app/build
RUN dotnet publish "OrderManagementApi.csproj" -c Release -o /app/publish

# Use the runtime image to serve the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "OrderManagementApi.dll"]
