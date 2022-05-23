FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Web.Consumer.API/Web.Consumer.API.csproj", "src/Web.Consumer.API/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
RUN dotnet restore "src/Web.Consumer.API/Web.Consumer.API.csproj"
COPY . .
WORKDIR "/src/src/Web.Consumer.API"
RUN dotnet build "Web.Consumer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.Consumer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Consumer.API.dll"]