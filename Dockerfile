FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY . ./

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 8080
EXPOSE 8081

WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "CineBucket.dll"]