#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TeslaOrder.API/TeslaOrder.API.csproj", "TeslaOrder.API/"]
RUN dotnet restore "TeslaOrder.API/TeslaOrder.API.csproj"
COPY . .
WORKDIR "/src/TeslaOrder.API"
RUN dotnet build "TeslaOrder.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeslaOrder.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeslaOrder.API.dll"]