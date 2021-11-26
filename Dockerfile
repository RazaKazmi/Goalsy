FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# restore dependencies
COPY Goalsy/*.csproj ./Goalsy/
COPY Goalsy.Tests/*.csproj ./Goalsy.Tests/
COPY *.sln .
RUN dotnet restore

# build
COPY . .
RUN dotnet build

# run tests
FROM build AS test-runner
WORKDIR /app/Goalsy.Tests
RUN dotnet test

# publish
FROM build AS publish 
WORKDIR /app/Goalsy
RUN dotnet publish -o out

# run
FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime
WORKDIR /app
COPY --from=publish /app/Goalsy/out .
ENTRYPOINT ["dotnet", "Goalsy.dll"]
