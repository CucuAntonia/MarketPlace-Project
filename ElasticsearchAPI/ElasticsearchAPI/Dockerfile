FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ElasticsearchAPI/ElasticsearchAPI.csproj", "ElasticsearchAPI/"]
RUN dotnet restore "ElasticsearchAPI/ElasticsearchAPI.csproj"
COPY . .
WORKDIR "/src/ElasticsearchAPI"
RUN dotnet build "ElasticsearchAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ElasticsearchAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElasticsearchAPI.dll"]
