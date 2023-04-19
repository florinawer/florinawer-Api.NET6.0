#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Trading.Presentation.Website/Trading.Presentation.Website.csproj", "Trading.Presentation.Website/"]
RUN dotnet restore "Trading.Presentation.Website/Trading.Presentation.Website.csproj"
COPY . .
WORKDIR "/src/Trading.Presentation.Website"
RUN dotnet build "Trading.Presentation.Website.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trading.Presentation.Website.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trading.Presentation.Website.dll"]