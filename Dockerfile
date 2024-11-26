# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory
WORKDIR /app

# Copy the csproj file(s) and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the entire source code and build in Release mode
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Use the runtime image for production
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Expose the application's port
EXPOSE 5151

# Run the application
ENTRYPOINT ["dotnet", "adilapi.dll"]
