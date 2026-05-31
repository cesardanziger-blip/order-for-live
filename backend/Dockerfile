FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build

WORKDIR /src

COPY ["OrderForLiveTest.API/OrderForLiveTest.API.csproj", "OrderForLiveTest.API/"]
COPY ["OrderForLiveTest.Application/OrderForLiveTest.Application.csproj", "OrderForLiveTest.Application/"]
COPY ["OrderForLiveTest.Domain/OrderForLiveTest.Domain.csproj", "OrderForLiveTest.Domain/"]
COPY ["OrderForLiveTest.Infrastructure/OrderForLiveTest.Infrastructure.csproj", "OrderForLiveTest.Infrastructure/"]

RUN dotnet restore "OrderForLiveTest.API/OrderForLiveTest.API.csproj"

COPY . .

WORKDIR "/src/OrderForLiveTest.API"

RUN dotnet publish "OrderForLiveTest.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS final

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
ENV DB_PATH=/app/orders.db

EXPOSE 8080

ENTRYPOINT ["dotnet", "OrderForLiveTest.API.dll"]