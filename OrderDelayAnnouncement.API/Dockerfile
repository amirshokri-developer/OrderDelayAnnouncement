

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["OrderDelayAnnouncement.API/OrderDelayAnnouncement.API.csproj", "OrderDelayAnnouncement.API/"]
COPY ["OrderDelayAnnouncement.Application/OrderDelayAnnouncement.Application.csproj", "OrderDelayAnnouncement.Application/"]
COPY ["OrderDelayAnnouncement.Domain/OrderDelayAnnouncement.Domain.csproj", "OrderDelayAnnouncement.Domain/"]
COPY ["OrderDelayAnnouncement.Infrastructure/OrderDelayAnnouncement.Infrastructure.csproj", "OrderDelayAnnouncement.Infrastructure/"]
RUN dotnet restore "OrderDelayAnnouncement.API/OrderDelayAnnouncement.API.csproj"
COPY . .
WORKDIR "/src/OrderDelayAnnouncement.API"
RUN dotnet build "OrderDelayAnnouncement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderDelayAnnouncement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderDelayAnnouncement.API.dll"]