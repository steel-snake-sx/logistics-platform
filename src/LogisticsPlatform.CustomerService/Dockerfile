FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LogisticsPlatform.CustomerService.csproj", "./"]
RUN dotnet restore "LogisticsPlatform.CustomerService.csproj"
COPY . .
RUN dotnet build "LogisticsPlatform.CustomerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogisticsPlatform.CustomerService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogisticsPlatform.CustomerService.dll"]
