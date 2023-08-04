FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

COPY FarmersMarketApi/*.csproj .
COPY FarmersMarketApi/FarmersMarket.db .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /publish

COPY --from=build-env /publish .
COPY --from=build-env FarmersMarket.db .
EXPOSE 80
ENV DOTNET_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "FarmersMarketApi.dll"]