using Contract.Api.Dto;
using FluentValidation;

namespace Contract.Api.Validators;

public class CreateContractDtoValidator : AbstractValidator<CreateContractDto>
{
    public CreateContractDtoValidator()
    {
        RuleFor(c =>c.OrderId).NotNull();
    }
}