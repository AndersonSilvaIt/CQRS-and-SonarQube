using FluentValidation.Results;
using Moq;
using ProductAPI.Application.Commands;
using ProductAPI.Application.Handlers;
using ProductAPI.Application.Validators;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;

namespace ProductAPI.Tests.Handlers
{
    public class CriaProdutoHandlerTests
    {
        [Fact]
        public async Task Handle_ComDadosValidos_DeveCriarProduto()
        {
            //Arrange
            var productReposutoryMock = new Mock<IProductRepository>();
            var validatorMock = new Mock<ProductCreateCommandValidator>();

            productReposutoryMock
                   .Setup(r => r.AddAsync(It.IsAny<Product>()))
                   .Returns(Task.CompletedTask);

            var handler = new ProductCreateHandler(productReposutoryMock.Object);

            var command = new ProductCreateCommand("Produto Teste", 100.0m, 10);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Empty(result.Errors);

            productReposutoryMock.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        }
    }
}