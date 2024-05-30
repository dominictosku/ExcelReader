FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ExcelReader/ExcelReader.csproj .
RUN dotnet restore ExcelReader.csproj
COPY ./ExcelReader .
RUN dotnet build ExcelReader.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ExcelReader.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf