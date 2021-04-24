#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TaleEngine/TaleEngine.csproj", "TaleEngine/"]
COPY ["TaleEngine.Data.Contracts/TaleEngine.Data.Contracts.csproj", "TaleEngine.Data.Contracts/"]
COPY ["TaleEngine.Bussiness/TaleEngine.Bussiness.csproj", "TaleEngine.Bussiness/"]
COPY ["TaleEngine.Bussiness.Contracts/TaleEngine.Bussiness.Contracts.csproj", "TaleEngine.Bussiness.Contracts/"]
COPY ["TaleEngine.Application.Contracts/TaleEngine.Application.Contracts.csproj", "TaleEngine.Application.Contracts/"]
COPY ["TaleEngine.Application/TaleEngine.Application.csproj", "TaleEngine.Application/"]
COPY ["TaleEngine.Data/TaleEngine.Data.csproj", "TaleEngine.Data/"]
RUN dotnet restore "TaleEngine/TaleEngine.csproj"
COPY . .
WORKDIR "/src/TaleEngine"
RUN dotnet build "TaleEngine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaleEngine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaleEngine.dll"]