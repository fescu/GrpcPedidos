using Moq;
using Xunit;

public class PedidoServiceTests
{
    [Fact]
    public async Task CrearPedidoAsync_DeberiaInsertarPedido()
    {
        // Arrange
        var repoMock = new Mock<IPedidoRepository>();
        var service = new PedidoService(repoMock.Object);

        var pedido = new Pedido { Id = "123", Nombre = "Test de pedidos" };

        // Act
        var resultado = await service.CrearPedidoAsync(pedido);

        // Assert
        repoMock.Verify(r => r.InsertAsync(pedido), Times.Once);
        Assert.Equal("123", resultado.Id);
        Assert.Equal("Test Pedido", resultado.Nombre);
    }
}
