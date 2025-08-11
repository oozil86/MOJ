using FluentValidation;
using MOJ.SharedKernel.Extensions;
using static MOJ.Application.Features.Supplier.CreateSupplier.CreateSupplier;

namespace MOJ.Application.Features.Supplier.CreateSupplier;

internal sealed class Validator
    : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotNullOrWhiteSpaceString();

    }
}
