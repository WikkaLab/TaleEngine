# - build project
from mcr.microsoft.com/dotnet/sdk:7.0 as build
workdir /TaleEngine
copy . .
run dotnet restore ".\TaleEngine\TaleEngine\TaleEngine.API.csproj" --disable-parallel
run dotnet publish ".\TaleEngine\TaleEngine\TaleEngine.API.csproj" -c release -o /app --no-restore

# - apply migrations
run dotnet tool install --global dotnet-ef --version 7.0.0
ENV PATH="${PATH}:/root/.dotnet/tools"
# run dotnet ef database update --project ".\TaleEngine\TaleEngine.Data\TaleEngine.Data.csproj"

# - serve env
from mcr.microsoft.com/dotnet/aspnet:7.0
workdir /app
copy --from=build /app ./

expose 5000

entrypoint ["dotnet", "TaleEngine.API.dll"]

# - utils

# build image
# docker build --rm -t dev/taleengine:latest .

# execute docker compose file
# docker-compose build

# run container
# docker run --rm -p 5000:5000 -p 5001:5001 -e ASPNETCORE_HTTP_PORT=https://+:5001 -e ASPNETCORE_URLS=http://+:5000 taleengine-api
# http://localhost:5000/swagger/index.html