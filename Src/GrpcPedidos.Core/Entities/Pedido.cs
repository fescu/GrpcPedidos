namespace GrpcPedidos.Core.Entities;

public class Pedido
{
    public string Id { get; set; } = null!;
    public string Cliente { get; set; } = null!;
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }

}