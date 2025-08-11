using FluentValidation;
using MOJ.SharedKernel.Extensions;
using static MOJ.Application.Features.Supplier.DeleteSupplier.DeleteSupplier;

namespace MOJ.Application.Features.Supplier.DeleteSupplier;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Reference).NotEmptyGuid();
    }
}