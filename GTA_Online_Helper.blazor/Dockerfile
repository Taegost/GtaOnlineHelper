#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GTA Online Helper/GTA_Online_Helper.blazor/GTA_Online_Helper.blazor.csproj", "GTA Online Helper/GTA_Online_Helper.blazor/"]
RUN dotnet restore "GTA Online Helper/GTA_Online_Helper.blazor/GTA_Online_Helper.blazor.csproj"
COPY . .
WORKDIR "/src/GTA Online Helper/GTA_Online_Helper.blazor"
RUN dotnet build "GTA_Online_Helper.blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GTA_Online_Helper.blazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GTA_Online_Helper.blazor.dll"]