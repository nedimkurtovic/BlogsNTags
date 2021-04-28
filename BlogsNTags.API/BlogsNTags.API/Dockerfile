FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 44313 9785
ENV ASPNETCORE_URLS=https://+:44313;http://+:9785

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "BlogsNTags.API" -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "BlogsNTags.API.dll"]