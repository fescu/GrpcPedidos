using Grpc.Core;
using GrpcPedidos.Application.Services;


namespace GrpcPedidos.Presentation.Services;

public class PedidosService : Pedidos.PedidosBase
{
    private readonly IPedidoService _pedidoService;
    public PedidosService(IPedidoService pedidoService) => _pedidoService = pedidoService;

    public override async Task<PedidoReply> CrearPedido(PedidoRequest request, ServerCallContext context)
    {
        await _pedidoService.CrearPedidoAsync(request.Cliente, (decimal)request.Total);
        return new PedidoReply { Mensaje = "Pedido creado" };
    }

    public override async Task<PedidosReply> ListarPedidos(Empty request,ServerCallContext context)
    {
        var pedidos = await _pedidoService.ListarPedidosAsync();
        var replay = new PedidosReply();
        replay.Pedidos.AddRange(pedidos.Select(p => new PedidoItem
        {
            Id = p.Id,
            Cliente = p.Cliente,
            Total = (double)p.Total,
            Fecha = p.Fecha.ToString("u")

        }));
        return replay;
    }
    




}