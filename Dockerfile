# Multi-stage build: compile with the full SDK, ship only the runtime image.
# The runtime image is far smaller and doesn't contain build tools, which is
# itself a small security win (less in the container to have vulnerabilities).

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Portfolio.csproj"
RUN dotnet publish "Portfolio.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Run as a non-root user (OWASP A05:2021 - don't run containers as root)
RUN adduser --disabled-password --home /app --gecos '' appuser && chown -R appuser /app
USER appuser

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Portfolio.dll"]
