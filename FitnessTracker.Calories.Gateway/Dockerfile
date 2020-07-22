#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FitnessTracker.Calories.Gateway/FitnessTracker.Calories.Gateway.csproj", "FitnessTracker.Calories.Gateway/"]
COPY ["FitnessTracker.Common/FitnessTracker.Common.csproj", "FitnessTracker.Common/"]
RUN dotnet restore "FitnessTracker.Calories.Gateway/FitnessTracker.Calories.Gateway.csproj"
COPY . .
WORKDIR "/src/FitnessTracker.Calories.Gateway"
RUN dotnet build "FitnessTracker.Calories.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FitnessTracker.Calories.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitnessTracker.Calories.Gateway.dll"]