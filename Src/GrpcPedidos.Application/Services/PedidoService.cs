using GrpcPedidos.Core.Entities;

namespace GrpcPedidos.Application.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _repository;
    public PedidoService(IPedidoRepository pedidoRepository) => _repository = pedidoRepository;
    public async Task CrearPedidoAsync(string cliente, decimal total)
    {
        var pedido = new Pedido {Cliente = cliente, Total = total };
        await _repository.CrearAsync(pedido);
    }

    public async Task<List<Pedido>> ListarPedidosAsync()
    {
       return await _repository.ListarAsync();
    }
}