using GrpcPedidos.Presentation.Services;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

// Configuración de gRPC inicial
builder.Services.AddGrpc();

// conexion de mongo en el docker
builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDb") ?? "mongodb://localhost:27017"));

builder.Services.AddSingleton(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase("PedidosDb");
});

// inyeccion de dependencias
builder.Services.AddScoped<GrpcPedidos.Core.Entities.IPedidoRepository, GrpcPedidos.Infrastructure.Repositories.PedidoRepository>();
builder.Services.AddScoped<GrpcPedidos.Application.Services.IPedidoService, GrpcPedidos.Application.Services.PedidoService>();

var app = builder.Build();

app.MapGrpcService<GrpcPedidos.Presentation.Services.PedidosService>();
app.MapGet("/", () => "Servicio gRPC Pedidos - use cliente gRPC.");

app.Run();
