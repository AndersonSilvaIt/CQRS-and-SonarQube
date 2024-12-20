using MediatR;
using Moq;
using ProductAPI.Application.DTOs;

namespace ProductAPI.Tests.Controllers
{
    public class ProdutoControllerTests
    {
        [Fact]
        public void ObterTodos_DeveRetornarOkComProdutos()
        {
            //Arrange
            var mediatrMock = new Mock<IMediator>();

            var produtos = new List<ProductDTO>
            {
                new ProductDTO{ Id = Guid.NewGuid(), Name = "Produto 1", Price = 10.0m },
                new ProductDTO{ Id = Guid.NewGuid(), Name = "Produto 2", Price = 20.0m }

            };
        }
    }
}