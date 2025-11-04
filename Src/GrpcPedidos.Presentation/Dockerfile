# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar todo el contenido del repositorio
COPY . .

# Restaurar dependencias
RUN dotnet restore "Src/GrpcPedidos.Presentation/GrpcPedidos.Presentation.csproj"

# Publicar la aplicación
RUN dotnet publish "Src/GrpcPedidos.Presentation/GrpcPedidos.Presentation.csproj" -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Exponer el puerto gRPC (ajústalo si usas otro)
EXPOSE 5295

ENTRYPOINT ["dotnet", "GrpcPedidos.Presentation.dll"]
