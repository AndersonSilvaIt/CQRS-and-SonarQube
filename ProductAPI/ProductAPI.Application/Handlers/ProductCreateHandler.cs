using MediatR;
using ProductAPI.Application.Commands;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;

namespace ProductAPI.Application.Handlers
{
    public class ProductCreateHandler : IRequestHandler<ProductCreateCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var preco = request.GetPrice();
            var product = new Product(request.Name, preco, request.Stock);

            await _productRepository.AddAsync(product);

            return true;
        }
    }
}