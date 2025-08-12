using FluentValidation;
using MOJ.SharedKernel.Extensions;
using static MOJ.Application.Features.Supplier.GetSupplier.GetSupplier;

namespace MOJ.Application.Features.Supplier.GetSupplier;

internal sealed class Validator
    : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Reference)
            .NotEmptyGuid();

    }
}
