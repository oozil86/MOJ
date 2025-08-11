using FluentValidation;
using MOJ.SharedKernel.Extensions;
using static MOJ.Application.Features.Supplier.UpdateSupplier.UpdateSupplier;


namespace MOJ.Application.Supplier.UpdateSupplier;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Reference).NotEmptyGuid();
        RuleFor(x => x.Name).NotNullOrWhiteSpaceString();
    }
}