FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY traba.io.sln ./
COPY Domain/*.csproj ./Domain/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY Infrastructure.Tests/*.csproj ./Infrastructure.Tests/
COPY Repository/*.csproj ./Repository/
COPY Repository.Tests/*.csproj ./Repository.Tests/
COPY WebApplication/*.csproj ./WebApplication/

RUN dotnet restore
COPY . .

WORKDIR /src/Domain
RUN dotnet build -c Release -o /app

WORKDIR /src/Infrastructure
RUN dotnet build -c Release -o /app

WORKDIR /src/Infrastructure.Tests
RUN dotnet build -c Release -o /app

WORKDIR /src/Repository
RUN dotnet build -c Release -o /app

WORKDIR /src/Repository.Tests
RUN dotnet build -c Release -o /app

WORKDIR /src/WebApplication
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApplication.dll"]
