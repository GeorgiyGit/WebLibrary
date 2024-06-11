#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Microservices/VirtualPeopleService/VirtualPeople.Api/VirtualPeople.Api.csproj", "Microservices/VirtualPeopleService/VirtualPeople.Api/"]
COPY ["Microservices/VirtualPeopleService/VirtualPeople.Application/VirtualPeople.Application.csproj", "Microservices/VirtualPeopleService/VirtualPeople.Application/"]
COPY ["Microservices/VirtualPeopleService/VirtualPeople.Domain/VirtualPeople.Domain.csproj", "Microservices/VirtualPeopleService/VirtualPeople.Domain/"]
COPY ["Microservices/VirtualPeopleService/VirtualPeople.Infrastructure/VirtualPeople.Infrastructure.csproj", "Microservices/VirtualPeopleService/VirtualPeople.Infrastructure/"]
RUN dotnet restore "./Microservices/VirtualPeopleService/VirtualPeople.Api/VirtualPeople.Api.csproj"
COPY . .
WORKDIR "/src/Microservices/VirtualPeopleService/VirtualPeople.Api"
RUN dotnet build "./VirtualPeople.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VirtualPeople.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VirtualPeople.Api.dll"]