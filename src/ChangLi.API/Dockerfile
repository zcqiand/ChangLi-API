#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Core/ChangLi/ChangLi.API/ChangLi.API.csproj", "src/Services/Core/ChangLi/ChangLi.API/"]
COPY ["src/Infrastructure/CommonMormon.Infrastructure.API/CommonMormon.Infrastructure.API.csproj", "src/Infrastructure/CommonMormon.Infrastructure.API/"]
COPY ["src/Infrastructure/CommonMormon.Infrastructure.Shared/CommonMormon.Infrastructure.Shared.csproj", "src/Infrastructure/CommonMormon.Infrastructure.Shared/"]
COPY ["src/Infrastructure/CommonMormon.Infrastructure/CommonMormon.Infrastructure.csproj", "src/Infrastructure/CommonMormon.Infrastructure/"]
COPY ["src/Services/Core/ChangLi/ChangLi.Domain/ChangLi.Domain.csproj", "src/Services/Core/ChangLi/ChangLi.Domain/"]
COPY ["src/Services/Core/ChangLi/ChangLi.Infrastructure/ChangLi.Infrastructure.csproj", "src/Services/Core/ChangLi/ChangLi.Infrastructure/"]
COPY ["src/Services/Core/ChangLi/ChangLi.Shared/ChangLi.Shared.csproj", "src/Services/Core/ChangLi/ChangLi.Shared/"]
RUN dotnet restore "src/Services/Core/ChangLi/ChangLi.API/ChangLi.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Core/ChangLi/ChangLi.API"
RUN dotnet build "ChangLi.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChangLi.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChangLi.API.dll"]