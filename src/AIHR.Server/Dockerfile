FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "src/"]
COPY ["Directory.Build.targets", "src/"]
COPY ["src/AIHR.Server/AIHR.Server.csproj", "src/AIHR.Server/"]
COPY ["src/AIHR.Domain/AIHR.Domain.csproj", "src/AIHR.Domain/"]
RUN dotnet restore "src/AIHR.Server/AIHR.Server.csproj"
COPY . .
RUN dotnet build "src/AIHR.Server/AIHR.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/AIHR.Server/AIHR.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "AIHR.Server.dll"]