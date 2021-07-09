# Author 
MAINTAINER aili <a.li@defacto.aero>
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CloudApps/ServerTestApp.csproj", "/src/CloudApps/"]
RUN dotnet restore "CloudApps/ServerTestApp.csproj"
COPY . .
WORKDIR "/src/CloudApps"
RUN dotnet build "ServerTestApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServerTestApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServerTestApp.dll"]
