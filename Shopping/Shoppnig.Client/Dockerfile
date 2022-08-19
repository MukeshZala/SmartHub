#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Shoppnig.Client/Shoppnig.Client.csproj", "Shoppnig.Client/"]
RUN dotnet restore "Shoppnig.Client/Shoppnig.Client.csproj"
COPY . .
WORKDIR "/src/Shoppnig.Client"
RUN dotnet build "Shoppnig.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shoppnig.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shoppnig.Client.dll"]