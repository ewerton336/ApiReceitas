# Usa a imagem oficial do ASP.NET Core 6 como base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Usa a imagem do SDK do .NET Core 6 para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiReceitas.csproj", "./"]
RUN dotnet restore "ApiReceitas.csproj"
COPY . .
RUN dotnet build "ApiReceitas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiReceitas.csproj" -c Release -o /app/publish

# Copia os arquivos publicados para a imagem base
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiReceitas.dll"]
