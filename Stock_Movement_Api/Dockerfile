#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Stock_Movement_Api/Stock_Movement_Api.csproj", "Stock_Movement_Api/"]
COPY ["StockMovement_Application/StockMovement_Application.csproj", "StockMovement_Application/"]
COPY ["StockMovementData/StockMovementData.csproj", "StockMovementData/"]
COPY ["StockMovement_Data/StockMovement_Domain.csproj", "StockMovement_Data/"]
COPY ["StockRabbitMQPublisher/StockRabbitMQPublisher.csproj", "StockRabbitMQPublisher/"]
RUN dotnet restore "Stock_Movement_Api/Stock_Movement_Api.csproj"
COPY . .
WORKDIR "/src/Stock_Movement_Api"
RUN dotnet build "Stock_Movement_Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stock_Movement_Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stock_Movement_Api.dll"]