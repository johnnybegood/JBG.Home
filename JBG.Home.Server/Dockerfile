FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY JBG.Home.Server/JBG.Home.Server.csproj JBG.Home.Server/
RUN dotnet restore
COPY . .
WORKDIR /src/JBG.Home.Server
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JBG.Home.Server.dll"]
