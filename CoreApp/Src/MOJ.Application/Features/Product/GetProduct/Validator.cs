using FluentValidation;
using MOJ.SharedKernel.Extensions;
using static MOJ.Application.Features.Product.GetProduct.GetProduct;

namespace MOJ.Application.Features.Product.GetProduct;

internal sealed class Validator
    : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Reference)
            .NotEmptyGuid();

    }
}
