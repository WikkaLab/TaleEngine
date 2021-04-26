#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "TaleEngine.sln" "TaleEngine.sln"

COPY ["TaleEngine/TaleEngine.csproj", "TaleEngine/"]
COPY ["TaleEngine.Data.Contracts/TaleEngine.Data.Contracts.csproj", "TaleEngine.Data.Contracts/"]
COPY ["TaleEngine.Bussiness/TaleEngine.Bussiness.csproj", "TaleEngine.Bussiness/"]
COPY ["TaleEngine.Bussiness.Contracts/TaleEngine.Bussiness.Contracts.csproj", "TaleEngine.Bussiness.Contracts/"]
COPY ["TaleEngine.Application.Contracts/TaleEngine.Application.Contracts.csproj", "TaleEngine.Application.Contracts/"]
COPY ["TaleEngine.Application/TaleEngine.Application.csproj", "TaleEngine.Application/"]
COPY ["TaleEngine.Data/TaleEngine.Data.csproj", "TaleEngine.Data/"]

COPY "docker-compose.dcproj" "docker-compose.dcproj"

COPY "NuGet.config" "NuGet.config"

RUN dotnet restore "TaleEngine.sln"

COPY . .
WORKDIR "/src/TaleEngine"
RUN dotnet publish --no-restore -c Release -o /app

FROM build as unittest
WORKDIR "/src/TaleEngine/TaleEngine.Testing"

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TaleEngine.dll"]