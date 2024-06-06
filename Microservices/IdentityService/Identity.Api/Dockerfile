#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Microservices/IdentityService/Identity.Api/Identity.Api.csproj", "Microservices/IdentityService/Identity.Api/"]
COPY ["Microservices/IdentityService/Identity.Application/Identity.Application.csproj", "Microservices/IdentityService/Identity.Application/"]
COPY ["Microservices/IdentityService/Identity.Domain/Identity.Domain.csproj", "Microservices/IdentityService/Identity.Domain/"]
COPY ["Microservices/IdentityService/Identity.Infrastructure/Identity.Infrastructure.csproj", "Microservices/IdentityService/Identity.Infrastructure/"]
RUN dotnet restore "./Microservices/IdentityService/Identity.Api/Identity.Api.csproj"
COPY . .
WORKDIR "/src/Microservices/IdentityService/Identity.Api"
RUN dotnet build "./Identity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Identity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]