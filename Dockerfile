FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["video_pujcovna_back.csproj", "video_pujcovna_back/"]
RUN dotnet restore "video_pujcovna_back.csproj"
COPY . .
WORKDIR "/src/video_pujcovna_back"
RUN dotnet build "video_pujcovna_back.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "video_pujcovna_back.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "video_pujcovna_back.dll"]
