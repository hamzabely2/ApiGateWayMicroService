#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV DOTNET_URLS=http://+:1000/

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Api.PotShop.ApiGateWayMicroService/Api.PotShop.ApiGateWayMicroService.csproj", "Api.PotShop.ApiGateWayMicroService/"]
RUN dotnet restore "./Api.PotShop.ApiGateWayMicroService/./Api.PotShop.ApiGateWayMicroService.csproj"
COPY . .
WORKDIR "/src/Api.PotShop.ApiGateWayMicroService"
RUN dotnet build "./Api.PotShop.ApiGateWayMicroService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.PotShop.ApiGateWayMicroService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 1000
ENTRYPOINT ["dotnet", "Api.PotShop.ApiGateWayMicroService.dll"]
