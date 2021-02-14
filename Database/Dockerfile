#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM  mcr.microsoft.com/mssql/server:2019-latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Leantavla/Server/Leantavla.Server.csproj", "Leantavla/Server/"]
COPY ["Leantavla/Shared/Leantavla.Shared.csproj", "Leantavla/Shared/"]
COPY ["Leantavla/Client/Leantavla.Client.csproj", "Leantavla/Client/"]

RUN dotnet restore "Leantavla/Server/Leantavla.Server.csproj"
COPY . .
WORKDIR "/src/Leantavla/Server"
RUN dotnet build "Leantavla.Server.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "Leantavla.Server.csproj" -c Release -o /app/publish
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:~/.dotnet/tools"
RUN dotnet ef migrations script --idempotent -o /app/publish/database.sql

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
 
ENTRYPOINT ["dotnet", "Leantavla.Server.dll"]