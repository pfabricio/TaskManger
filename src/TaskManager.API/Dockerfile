
# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TaskManagerApi/TaskManagerApi.csproj", "TaskManagerApi/"]
RUN dotnet restore "TaskManagerApi/TaskManagerApi.csproj"
COPY . .
WORKDIR "/src/TaskManagerApi"
RUN dotnet build "TaskManagerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManagerApi.csproj" -c Release -o /app/publish

# Copy the build result to the final base image and define entrypoint
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagerApi.dll"]
