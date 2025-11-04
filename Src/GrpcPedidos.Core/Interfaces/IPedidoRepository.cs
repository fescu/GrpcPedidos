using GrpcPedidos.Core.Entities;
namespace GrpcPedidos.Core.Entities
{
    public interface IPedidoRepository
    {
        Task CrearAsync(Pedido pedido);
        Task<List<Pedido>> ListarAsync();
    }
}
