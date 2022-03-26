#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5004
#EXPOSE 443
ENV ASPNETCORE_URLS=http://*:5004
# ENV ASPNETCORE_URLS=https://*:5001
# ENV ASPNETCORE_HTTPS_PORT=5001
# ENV ASPNETCORE_Kestrel__Certificates__Default__Password="password"
# ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ./src .
RUN dotnet restore "Galactic.Core/Galactic.Core.csproj"
WORKDIR "/src/Galactic.Core"
COPY . .
RUN dotnet build "Galactic.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Galactic.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Galactic.Core.dll"]