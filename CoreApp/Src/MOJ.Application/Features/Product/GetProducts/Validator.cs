using FluentValidation;
using MOJ.SharedKernel.Extensions;
using static MOJ.Application.Features.Product.GetProducts.GetProducts;

namespace MOJ.Application.Features.Product.GetProducts;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotNullOrWhiteSpaceString();
    }
}