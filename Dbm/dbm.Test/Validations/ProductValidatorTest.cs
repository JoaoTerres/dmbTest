using System.Threading.Tasks;
using dbm.Api.DTO;
using dbm.Api.Models;
using dbm.Api.Repositories.Interfaces;
using dbm.Api.Validations;
using FluentValidation.TestHelper;
using Moq;
using Xunit;

namespace dbm.Test.Validations
{
    public class ProductValidatorTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly ProductValidator _validator;

        public ProductValidatorTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _validator = new ProductValidator(_mockProductRepository.Object);
        }

        [Fact]
        public async Task Should_Have_Error_When_Name_Is_Empty()
        {
            var product = new ProductDTO { Name = "", Price = 10 };

            var result = await _validator.TestValidateAsync(product);

            result.ShouldHaveValidationErrorFor(x => x.Name)
                  .WithErrorMessage("O nome é obrigatório.");
        }

        [Fact]
        public async Task Should_Have_Error_When_Name_Exceeds_Maximum_Length()
        {
            var product = new ProductDTO { Name = new string('A', 101), Price = 10 };

            var result = await _validator.TestValidateAsync(product);

            result.ShouldHaveValidationErrorFor(x => x.Name)
                  .WithErrorMessage("O nome não pode ter mais de 100 caracteres.");
        }

        [Fact]
        public async Task Should_Have_Error_When_Name_Is_Not_Unique()
        {
            var existingProduct = new Product { Name = "Existing Product", Price = 10 };

            _mockProductRepository.Setup(repo => repo.GetByNameAsync(It.IsAny<string>()))
                                  .ReturnsAsync(existingProduct);

            var productDto = new ProductDTO { Name = "Existing Product", Price = 10 };

            var result = await _validator.TestValidateAsync(productDto);

            result.ShouldHaveValidationErrorFor(x => x.Name)
                  .WithErrorMessage("O nome já está em uso. Escolha um nome diferente.");
        }



        [Fact]
        public async Task Should_Have_Error_When_Price_Is_Less_Than_Or_Equal_To_Zero()
        {
            var product = new ProductDTO { Name = "Valid Name", Price = 0 };

            var result = await _validator.TestValidateAsync(product);

            result.ShouldHaveValidationErrorFor(x => x.Price)
                  .WithErrorMessage("O preço deve ser maior que zero.");
        }

        [Fact]
        public async Task Should_Have_Error_When_Price_Is_Null()
        {
            var product = new ProductDTO { Name = "Valid Name", Price = null };

            var result = await _validator.TestValidateAsync(product);

            result.ShouldHaveValidationErrorFor(x => x.Price)
                  .WithErrorMessage("O preço é obrigatório.");
        }

        [Fact]
        public async Task Should_Not_Have_Error_When_Valid_Data()
        {
            _mockProductRepository.Setup(repo => repo.GetByNameAsync(It.IsAny<string>()))
                                  .ReturnsAsync((Product)null); 

            var product = new ProductDTO { Name = "Unique Product", Price = 10 };

            var result = await _validator.TestValidateAsync(product);

            // Não deve haver erros de validação
            result.ShouldNotHaveAnyValidationErrors();
        }

    }
}
