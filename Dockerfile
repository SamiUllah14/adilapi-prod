# Use the official .NET SDK image for building and running in development
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS development

# Set the working directory in the container
WORKDIR /app

# Copy the csproj file(s) and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the entire source code
COPY . ./

# Expose the ports the app will run on
EXPOSE 5000

# Enable hot reload capabilities (optional for development mode)
ENV DOTNET_USE_POLLING_FILE_WATCHER=true

# Start the application with hot reload
CMD ["dotnet", "watch", "run", "--urls=http://0.0.0.0:5151"]
