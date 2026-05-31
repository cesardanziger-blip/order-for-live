using FluentAssertions;
using Moq;
using OrderForLiveTest.Application.DTOs.Requests;
using OrderForLiveTest.Application.Services;
using OrderForLiveTest.Domain.Entities;
using OrderForLiveTest.Domain.Interfaces;
using Xunit;

namespace OrderForLiveTest.Tests.Services;

public class OrderServiceTests
{
    private readonly Mock<IOrderRepository> _repositoryMock;
    private readonly OrderService _service;

    public OrderServiceTests()
    {
        _repositoryMock = new Mock<IOrderRepository>();

        _service = new OrderService(_repositoryMock.Object);
    }

    //1.Verifica se o repositório é chamado corretamente para criar um pedido
    [Fact]
    public async Task CreateAsync_Should_Create_Order_Successfully()
    {
        var request = new CreateOrderRequest
        {
            CustomerName = "Cesar",
            Items =
            [
                new CreateOrderItemRequest
                {
                    ProductName = "Mouse",
                    Quantity = 2,
                    Price = 100
                }
            ]
        };

        await _service.CreateAsync(request);

        _repositoryMock.Verify(
            x => x.CreateAsync(It.IsAny<Order>()),
            Times.Once);
    }

    //2.Verifica se o serviço retorna todos os pedidos corretamente
    [Fact]
    public async Task GetAllAsync_Should_Return_All_Orders()
    {
        // Arrange
        var orders = new List<Order>
        {
            new(
                "Cesar",
                [
                    new("Mouse", 1, 100)
                ]),
    
            new(
                "Maria",
                [
                    new("Teclado", 2, 200)
                ])
        };

        _repositoryMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(orders);

        // Act
        var result = await _service.GetAllAsync();
    
        // Assert
        result.Should().NotBeNull();

        result.Should().HaveCount(2);

        result.Should().BeEquivalentTo(orders);
    }

    //3.Verifica se o serviço retorna um pedido específico quando ele existe
    [Fact]
    public async Task GetByIdAsync_Should_Return_Order_When_Order_Exists()
    {
        // Arrange
        var orderId = Guid.NewGuid();

        var order = new Order(
            "Cesar",
            new List<OrderItem>
            {
            new("Mouse", 1, 100)
            });

        _repositoryMock
            .Setup(x => x.GetByIdAsync(orderId))
            .ReturnsAsync(order);

        // Act
        var result = await _service.GetByIdAsync(orderId);

        // Assert
        result.Should().NotBeNull();

        result.Should().Be(order);
    }

    //4.Verifica se o serviço retorna nulo quando o pedido não existe
    [Fact]
    public async Task GetByIdAsync_Should_Return_Null_When_Order_Does_Not_Exist()
    {
        var orderId = Guid.NewGuid();

        _repositoryMock
            .Setup(x => x.GetByIdAsync(orderId))
            .ReturnsAsync((Order?)null);

        var result = await _service.GetByIdAsync(orderId);

        result.Should().BeNull();
    }

    //5. Verifica se o serviço chama o repositório para deletar um pedido
    [Fact]
    public async Task DeleteAsync_Should_Call_Repository_Delete()
    {
        var orderId = Guid.NewGuid();

        await _service.DeleteAsync(orderId);

        _repositoryMock.Verify(
            x => x.DeleteAsync(orderId),
            Times.Once);
    }

    //6. Verifica se o serviço cria um pedido com os valores corretos
    [Fact]
    public async Task CreateAsync_Should_Create_Order_With_Correct_Values()
    {
        // Arrange
        var request = new CreateOrderRequest
        {
            CustomerName = "João",
            Items = new List<CreateOrderItemRequest>
            {
                new()
                {
                    ProductName = "Teclado",
                    Quantity = 1,
                    Price = 300
                }
            }
        };

        Order? capturedOrder = null;

        _repositoryMock
            .Setup(x => x.CreateAsync(It.IsAny<Order>()))
            .Callback<Order>(order =>
            {
                capturedOrder = order;
            });

        await _service.CreateAsync(request);

        capturedOrder.Should().NotBeNull();

        capturedOrder!.CustomerName.Should().Be("João");

        capturedOrder.Items.Should().HaveCount(1);

        capturedOrder.Items.First().ProductName.Should().Be("Teclado");

        capturedOrder.Items.First().Quantity.Should().Be(1);

        capturedOrder.Items.First().Price.Should().Be(300);
    }

}