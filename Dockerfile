FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app
EXPOSE 80

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

RUN dotnet publish -c Release -o /app

WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApplication.dll"]
