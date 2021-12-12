FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GitLabWebhook/GitLabWebhook.csproj", "GitLabWebhook/"]
RUN dotnet restore "GitLabWebhook/GitLabWebhook.csproj"
COPY . .
WORKDIR "/src/GitLabWebhook"

RUN dotnet tool install --global dotnet-ef && dotnet-ef database update
RUN dotnet build "GitLabWebhook.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GitLabWebhook.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet GitLabWebhook.dll
