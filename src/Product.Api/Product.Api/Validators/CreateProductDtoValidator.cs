using FluentValidation;
using Product.Api.Entities.Dtos;

namespace Product.Api.Validators;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(productDto => productDto.Name)
            .NotNull()
            .Length(1, 50);

        RuleFor(productDto => productDto.Price)
            .NotNull()
            .GreaterThan(-1);

        RuleFor(productDto => productDto.CategoryId)
            .NotNull();

        RuleFor(productDto => productDto.Description)
            .NotNull()
            .NotEmpty();

        RuleFor(productDto => productDto.Count)
            .NotNull();
    }
}