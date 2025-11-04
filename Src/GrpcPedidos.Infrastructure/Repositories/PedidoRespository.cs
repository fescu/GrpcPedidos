using GrpcPedidos.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GrpcPedidos.Infrastructure.Repositories;

public class PedidoRepository(IMongoDatabase db) : IPedidoRepository
{

    private readonly IMongoCollection<Pedido> _collection = db.GetCollection<Pedido>("Pedidos");

    public async Task CrearAsync(Pedido pedido)
    {
        pedido.Id = ObjectId.GenerateNewId().ToString();
        await _collection.InsertOneAsync(pedido);
    }

    public async Task<List<Pedido>> ListarAsync() => await _collection.Find(_ => true).ToListAsync();
    
}