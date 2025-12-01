using Moq;
using Xunit;
using GrpcPedidos.Application.Services;
using GrpcPedidos.Core.Entities;

namespace GrpcPedidos.Tests;

public class PedidoServiceTests
{
    [Fact]
    public async Task CrearPedidoAsync_DeberiaCrearPedidoEnRepositorio()
    {
        // Arrange
        var repoMock = new Mock<IPedidoRepository>();
        var service = new PedidoService(repoMock.Object);

        string cliente = "Felipe";
        decimal total = 100m;

        // Act
        await service.CrearPedidoAsync(cliente, total);

        // Assert
        repoMock.Verify(r => r.CrearAsync(
            It.Is<Pedido>(p => p.Cliente == cliente && p.Total == total)),
            Times.Once);
    }


    [Fact]
    public async Task ListarPedidosAsync_DeberiaRetornarListaDesdeRepositorio()
    {
        // Arrange
        var repoMock = new Mock<IPedidoRepository>();
        var pedidosEsperados = new List<Pedido>
        {
            new Pedido{ Cliente = "A", Total = 10 },
            new Pedido{ Cliente = "B", Total = 20 }
        };

        repoMock.Setup(r => r.ListarAsync()).ReturnsAsync(pedidosEsperados);

        var service = new PedidoService(repoMock.Object);

        // Act
        var resultado = await service.ListarPedidosAsync();

        // Assert
        Assert.Equal(2, resultado.Count);
        Assert.Equal("A", resultado[0].Cliente);
        Assert.Equal(20, resultado[1].Total);
    }
}
