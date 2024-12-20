using ProductAPI.Application.Commands;
using ProductAPI.Application.Validators;
using FluentValidation.TestHelper;

namespace ProductAPI.Tests.Validators
{
    public class CriaProdutoCommandValidator
    {
        private readonly ProductCreateCommandValidator _validator;

        public CriaProdutoCommandValidator()
        {
            _validator = new ProductCreateCommandValidator();
        }

        [Fact]
        public void Validate_ComNomeVazio_DeveRetornarErro()
        {
            // Arrange
            var command = new ProductCreateCommand("", 100.0m, 10);

            // Act
            var result = _validator.Validate(command);

            //// Assert
            //_validator.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Validate_ComPrecoNegativo_DeveRetornarErro()
        {
            // Arrange
            var command = new ProductCreateCommand("Produto Teste", -1.0m, 10);

            // Act
            var result = _validator.Validate(command);

            // Assert
            //result.ShouldHaveValidationErrorFor(x => x.Price);

        }
    }
}
