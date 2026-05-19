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

# =====================================================================
# THÊM MỚI: Cài đặt dependency cho wkhtmltopdf trên Linux Cloud Run
# =====================================================================
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        libfontconfig1 \
        libxrender1 \
        libxext6 \
        libx11-6 \
        libc6-dev \
        libgdiplus \
        wget \
    && rm -rf /var/lib/apt/lists/*

# Tải file libwkhtmltox.so bản 64-bit trực tiếp vào thư mục /app và cấp quyền thực thi
RUN wget https://github.com/rdvojmoc/DinkToPdf/raw/master/v0.12.4/64%20bit/libwkhtmltox.so -O /app/libwkhtmltox.so \
    && chmod +x /app/libwkhtmltox.so
# =====================================================================


# Cloud Run listens on 8080 by default.
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BookingCare.Api.dll"]