FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

COPY FarmersMarketApi/*.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /publish

COPY --from=build-env /publish .
EXPOSE 80

ENTRYPOINT ["dotnet", "FarmersMarketApi.dll"]