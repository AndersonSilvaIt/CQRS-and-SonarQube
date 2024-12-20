using MediatR;
using ProductAPI.Application.Commands;
using ProductAPI.Application.DTOs;
using ProductAPI.Application.Models;
using ProductAPI.Application.Validators;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;

namespace ProductAPI.Application.Handlers
{
    public class ProductCreateHandler : IRequestHandler<ProductCreateCommand, OperationResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductCreateCommandValidator _validator;
        public ProductCreateHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _validator = new ProductCreateCommandValidator();
        }

        public async Task<OperationResult> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {

            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return OperationResult.Fail("Validation fail", errors);
            }

            try
            {
                var preco = request.GetPrice();
                var product = new Product(request.Name, preco, request.Stock);

                await _productRepository.AddAsync(product);

                var productDto = ProductDTO.FromProduct(product);

                return OperationResult.Ok("Product created with success", data: productDto);
            }
            catch (ArgumentException aex)
            {
                return OperationResult.Fail("Validation fail", new List<string> { aex.Message });
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Internal Error", new List<string> { ex.Message });
            }
        }
    }
}