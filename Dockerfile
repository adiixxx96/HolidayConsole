FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /Practicas
EXPOSE 1000
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "HolidayConsole.dll"]
#ENTRYPOINT ["/bin/bash"]
