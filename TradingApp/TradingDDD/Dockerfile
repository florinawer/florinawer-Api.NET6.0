#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TradingDDD.Web.Api/TradingDDD.Web.Api.csproj", "TradingDDD.Web.Api/"]
COPY ["TradingDDD.Application.Services/TradingDDD.Application.Services.csproj", "TradingDDD.Application.Services/"]
COPY ["TradingDDD.Domain.Entities/TradingDDD.Domain.Entities.csproj", "TradingDDD.Domain.Entities/"]
COPY ["TradingDDD.Infrastructure.Data.Model/TradingDDD.Infrastructure.Data.Model.csproj", "TradingDDD.Infrastructure.Data.Model/"]
COPY ["TradingDDD.Infrastructure.Repository/TradingDDD.Infrastructure.Repository.csproj", "TradingDDD.Infrastructure.Repository/"]
COPY ["TradingDDD.Infrastructure.Persistence/TradingDDD.Infrastructure.Persistence.csproj", "TradingDDD.Infrastructure.Persistence/"]
COPY ["TradingDDD.Web.Dto/TradingDDD.Web.Dto.csproj", "TradingDDD.Web.Dto/"]
RUN dotnet restore "TradingDDD.Web.Api/TradingDDD.Web.Api.csproj"
COPY . .
WORKDIR "/src/TradingDDD.Web.Api"
RUN dotnet build "TradingDDD.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TradingDDD.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TradingDDD.Web.Api.dll"]