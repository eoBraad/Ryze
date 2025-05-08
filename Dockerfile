# Etapa 1: build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia os arquivos do projeto
COPY src/ ./src/

# Restaura os pacotes NuGet
WORKDIR /app/src/ProjetoApi
RUN dotnet restore

# Build em modo Release
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: imagem runtime leve para produção
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copia os arquivos publicados da etapa anterior
COPY --from=build /app/publish .

# Expõe a porta padrão
EXPOSE 80

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "ProjetoApi.dll"]
