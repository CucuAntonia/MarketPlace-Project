#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["ElasticsearchAPI/ElasticsearchAPI.csproj", "ElasticsearchAPI/"]
#RUN dotnet restore "ElasticsearchAPI/ElasticsearchAPI.csproj"
#COPY . .
#WORKDIR "/src/ElasticsearchAPI"
#RUN dotnet build "ElasticsearchAPI.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "ElasticsearchAPI.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ElasticsearchAPI.dll"]


#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /source
#COPY . .
#RUN dotnet restore "ElasticsearchAPI/ElasticsearchAPI.csproj" --disable-parallel
#RUN dotnet publish "ElasticsearchAPI/ElasticsearchAPI.csproj" -c release -o /app --no-restore


#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS build
#WORKDIR /app
#COPY --from=build /app ./

#EXPOSE 5000

#ENTRYPOINT ["dotnet", "ElasticsearchAPI.dll"]


# Set the base image to the official .NET 7 SDK image
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory in the container
#WORKDIR /app

# Copy the project files into the container
#COPY . .

# Restore the NuGet packages
#RUN dotnet restore

# Build the project
#RUN dotnet build -c Release

# Publish the project
#RUN dotnet publish -c Release -o out

# Set the base image to the official Elasticsearch image
#FROM docker.elastic.co/elasticsearch/elasticsearch:7.13.4

# Copy the published files into the container
#COPY --from=build /app/out /app

# Set the working directory in the container
#WORKDIR /app

# Expose port 80 for the REST API
#EXPOSE 80

# Set environment variables for Elasticsearch
#ENV discovery.type=single-node
#ENV ES_JAVA_OPTS="-Xms512m -Xmx512m"

# Start Elasticsearch and the REST API
#CMD service elasticsearch start && dotnet ElasticsearchAPI.dll


# Set the base image to use
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the source code and build the project
COPY . ./
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

# Set the environment variables for Elasticsearch connection
#ENV Elasticsearch__Url=http://elasticsearch:9200

# Expose the port
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "ElasticsearchAPI.dll"]

