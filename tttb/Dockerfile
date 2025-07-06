ARG ARCH=amd64
ARG TAG=9.0-bookworm-slim-$ARCH
FROM mcr.microsoft.com/dotnet/aspnet:$TAG AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["tttb.csproj", "./"]
RUN dotnet restore "tttb.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "tttb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tttb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tttb.dll"]