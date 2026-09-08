# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY HanziRush.Api/*.csproj ./HanziRush.Api/
COPY HanziRush.Application/*.csproj ./HanziRush.Application/
COPY HanziRush.Domain/*.csproj ./HanziRush.Domain/
COPY HanziRush.Infrastructure/*.csproj ./HanziRush.Infrastructure/
RUN dotnet restore ./HanziRush.Api/
RUN dotnet restore ./HanziRush.Application/
RUN dotnet restore ./HanziRush.Domain/
RUN dotnet restore ./HanziRush.Infrastructure/

# copy everything else and build app
COPY . .
WORKDIR /source/.
RUN dotnet publish ./HanziRush.Api -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_HTTP_PORTS=8000

ENTRYPOINT ["dotnet", "HanziRush.Api.dll"]