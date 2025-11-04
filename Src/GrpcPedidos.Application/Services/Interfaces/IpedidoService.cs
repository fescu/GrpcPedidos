using GrpcPedidos.Core.Entities;

namespace GrpcPedidos.Application.Services;

public interface IPedidoService
{
    Task CrearPedidoAsync(string cliente, decimal total);
    Task<List<Pedido>> ListarPedidosAsync();
}