#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TaskAPI/TaskAPI.csproj", "TaskAPI/"]
COPY ["Persistence.EF/Persistence.EF.csproj", "Persistence.EF/"]
COPY ["Application.Core/Application.Core.csproj", "Application.Core/"]
COPY ["Domain.Core/Domain.Core.csproj", "Domain.Core/"]
RUN dotnet restore "TaskAPI/TaskAPI.csproj"
COPY . .
WORKDIR "/src/TaskAPI"
RUN dotnet build "TaskAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskAPI.dll"]