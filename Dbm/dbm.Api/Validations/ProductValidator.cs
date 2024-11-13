using dbm.Api.DTO;
using dbm.Api.Repositories.Interfaces;
using FluentValidation;

namespace dbm.Api.Validations;

public class ProductValidator : AbstractValidator<ProductDTO>
{
    private readonly IProductRepository _productRepository;

    public ProductValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;

        RuleFor(product => product.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(100).WithMessage("O nome não pode ter mais de 100 caracteres.")
            .MustAsync(async (name, cancellation) => await IsUniqueName(name))
            .WithMessage("O nome já está em uso. Escolha um nome diferente.");

        RuleFor(product => product.Price)
            .NotNull().WithMessage("O preço é obrigatório.")
            .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
    }

    private async Task<bool> IsUniqueName(string name)
    {
        var existingProduct = await _productRepository.GetByNameAsync(name);
        return existingProduct == null;
    }
}
