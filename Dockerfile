FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files first for better layer caching.
COPY ["BookingCare.Api/BookingCare.Api.csproj", "BookingCare.Api/"]
COPY ["BookingCare.Application/BookingCare.Application.csproj", "BookingCare.Application/"]
COPY ["BookingCare.Domain/BookingCare.Domain.csproj", "BookingCare.Domain/"]
COPY ["BookingCare.Infrastructure/BookingCare.Infrastructure.csproj", "BookingCare.Infrastructure/"]
COPY ["BookingCare.Shared/BookingCare.Shared.csproj", "BookingCare.Shared/"]
RUN dotnet restore "BookingCare.Api/BookingCare.Api.csproj"

# Copy the full source and publish.
COPY . .
RUN dotnet publish "BookingCare.Api/BookingCare.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Cloud Run listens on 8080 by default.
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BookingCare.Api.dll"]
